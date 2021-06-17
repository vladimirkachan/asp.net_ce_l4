using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _01_Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            RouteBuilder builder = new(app);
            builder.MapRoute("Home", async context =>
            {
                await context.Response.WriteAsync("<h1>Home page</h1>");
            });
            builder.MapRoute("home/names", async context =>
            {
                string[] names = {"VovA", "Anna", "Aleks", "Ira"};
                await context.Response.WriteAsync("<h2>Names:</h2>");
                foreach (var n in names)
                    await context.Response.WriteAsync($"<p>{n}</p>");
            });
            app.UseRouter(builder.Build());

            //app.UseRouting();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("<p>Default page</p>");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("<p>Default page</p>");
            //    });
            //});
        }
    }
}
