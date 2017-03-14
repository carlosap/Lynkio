using System.Threading.Tasks;
using Senserv.Model;
namespace Senserv.Interfaces
{
    public interface IProduct
    {
        Task<Product> Get(string serial,string value, string cache);
    }
}
