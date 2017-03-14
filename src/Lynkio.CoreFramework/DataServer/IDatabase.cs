using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer
{
    public interface IDatabase
    {
        DatabaseServerType ServerType { get; }
        Task Initialise();
        Task<string> GetConnectionString();
        Task<int> GetTimeOut();  
    }
}
