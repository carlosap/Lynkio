using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senserv.Interfaces;
namespace Senserv.Controllers
{
    //api/sensor?serial=TESTBETA123&value=fahrenheit
    [Route("api/[controller]")]
    public class SensorController : Controller
    {
        public ISensor Sensor { get; set; }
        public SensorController(ISensor sensor) { Sensor = sensor; }
        public async Task<object> Get([FromQuery]string serial, string value)
        {
            return await Task.Run(async () => {
                var sensor = await Sensor.Get(serial, value);
                return sensor;
            });
        }
    }
}



