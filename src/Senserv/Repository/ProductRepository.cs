using System;
using System.Linq;
using System.Threading.Tasks;
using Lynkio.CoreFramework;
using Senserv.Interfaces;
using Senserv.Model;
using Lynkio.CoreFramework.Cache;
using Lynkio.CoreFramework.Extensions;
namespace Senserv.Repository
{
    public class ProductRepository: IProduct
    {
        private static Product _product;
        public async Task<Product> Get(string serial,string value,string cache)
        {
            var isCache = Convert.ToBoolean(string.IsNullOrWhiteSpace(cache) ? "true" : "false");
            return await Task.Run(async () =>
            {
                var cacheKey = string.Format(Config.Cache.ProductKey, serial);
                _product = await GetProductCache(isCache, cacheKey);
                if (!value.Contains("|")) return _product;
                var meas = value.Split('|');
                _product.SerialNumber = serial;
                _product.Value = value;
                foreach (var measurement in meas)
                {
                    if (!measurement.Contains("=")) continue;
                    var measUnit = measurement.Split('=').GetValue(0).ToString().ToLower();
                    var measValue = measurement.Split('=').GetValue(1).ToString().TryParseDecimal() ?? 0;
                    switch (measUnit)
                    {
                        case "fahrenheit":
                        case "celsius":
                        case "kelvin":
                        case "ppm":
                        case "ppb":
                        case "humidity":
                            SetProductSensorByName(measUnit, measValue);
                            SetPartialSensorCache(_product.SerialNumber, measUnit, measValue);
                            break;
                    }
                }

                Memory.SetAndExpiresDays(cacheKey, _product);
                Publishers.ProductLogger.Log(_product);
                return _product;
            });
        }

        private static async void SetProductSensorByName(string sensorType, decimal value)
        {
            await Task.Run(() =>
            {
               var sensor = (from items in _product.Sensors
                             where items.Type.Equals(sensorType)
                             select items).FirstOrDefault();

               if (sensor != null)
               {
                   sensor.Histogram.Enqueue(value);
               }
               else
               {
                   sensor = new Sensor {Type = sensorType};
                   sensor.Histogram.Enqueue(value);
                   _product.Sensors.Add(sensor);
               }             
            });
        }
        private static async Task<Product> GetProductCache(bool isCache, string cacheKey)
        {
            var product = new Product();
            if (!isCache)
                Memory.Remove(cacheKey);
            else
                product = await Memory.Get<Product>(cacheKey) ?? new Product();

            return product;
        }
        private static async void SetPartialSensorCache(string serial, string sensorType, decimal value)
        {
            await Task.Run(async () =>
            {
                var cachekey = string.Format(Config.Cache.SensorKey, serial, sensorType);
                var sensor = await Memory.Get<Sensor>(cachekey) ?? new Sensor();
                sensor.Type = sensorType;
                sensor.Histogram.Enqueue(value);
                Memory.SetAndExpiresDays(cachekey, sensor);
            }); 
        }
    }
}
