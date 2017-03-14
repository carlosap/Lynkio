using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senserv.Interfaces;
namespace Senserv.Controllers
{
    ////api/product?serial=TESTBETA123&value=fahrenheit=88.45|celsius=85.80|kelvin=298.95|humidity=84.82|ppm=323|ppb=424
    ///api/product?serial=TESTBETA123&value=fahrenheit=88.45|celsius=85.80|kelvin=298.95|humidity=84.82|ppm=323|ppb=424&cache=no
    ///GET - > api/product?value=TESTBETA123
    [Route("api/[controller]")]
    public class ProductController: Controller
    {
        public IProduct Product { get; set; }
        public ProductController(IProduct product){Product = product;}
        public async Task<object> Get([FromQuery]string serial,string value,string cache)
        {
            return await Task.Run(async () => {
                    var product = await Product.Get(serial,value,cache);
                    return product;
            });
        }
    }
}
