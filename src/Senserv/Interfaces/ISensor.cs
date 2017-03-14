using System.Threading.Tasks;
using Senserv.Model;
namespace Senserv.Interfaces
{
    public interface ISensor
    {
        Task<Sensor> Get(string serial,string sensorType);
    }
}
