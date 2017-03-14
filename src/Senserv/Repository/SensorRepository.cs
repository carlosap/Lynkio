using System.Threading.Tasks;
using Lynkio.CoreFramework;
using Senserv.Interfaces;
using Senserv.Model;
using Lynkio.CoreFramework.Cache;
namespace Senserv.Repository
{
    public class SensorRepository: ISensor
    {
        public async Task<Sensor> Get(string serial, string sensorType)
        {
            return await Task.Run(async () =>
            {
                var cacheKey = string.Format(Config.Cache.SensorKey, serial, sensorType);
                return await Memory.Get<Sensor>(cacheKey) ?? new Sensor();
            });
        }
    }
}
