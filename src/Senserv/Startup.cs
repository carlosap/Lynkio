using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Senserv.Interfaces;
using Senserv.Repository;
namespace Senserv
{
    public class Startup
    {
        public Publishers Publishers { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            //--Publishers------
            Publishers = new Publishers();
            services.AddMvc();
            services.AddSingleton<IProduct, ProductRepository>();
            services.AddSingleton<ISensor, SensorRepository>();
            services.AddSingleton<IDataSource, DataSourceRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
