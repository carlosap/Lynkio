using System.Threading.Tasks;
namespace Senserv.Interfaces
{
    public interface IDataSource
    {
        Task<object> Get(string name, string cache);
    }
}
