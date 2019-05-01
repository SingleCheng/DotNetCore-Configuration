using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IConfiguration config)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is ASP.NET Core! \n");
                await context.Response.WriteAsync(
                    string.Format("The value in appsettings.json at key 'SampleKey':'{0}'", config["SampleKey"]));
            });
        }
    }
}