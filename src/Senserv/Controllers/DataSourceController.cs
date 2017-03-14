using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senserv.Interfaces;

namespace Senserv.Controllers
{
    /// api/datasource?name=menu
    [Route("api/[controller]")]
    public class DataSourceController : Controller
    {
        public DataSourceController(IDataSource datasource)
        {
            DataSource = datasource;
        }
        public IDataSource DataSource { get; set; }
        public async Task<object> Get([FromQuery] string name, string cache)
        {
            return await Task.Run(async () =>
            {
                var datasource = await DataSource.Get(name,cache);               
                return datasource;
            });
        }
    }
}
