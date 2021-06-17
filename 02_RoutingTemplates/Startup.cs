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

namespace _02_RoutingTemplates
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            RouteBuilder route = new(app);
            route.MapRoute("multi/{action}/{*catchall}", async context =>
            {
                await context.Response.WriteAsync("Route multi/{action}/{*catchall}");
            });
            route.MapRoute("vova/{action}", async context =>
            {
                await context.Response.WriteAsync("Route VovA/{action}");
            });
            route.MapRoute("{controller}", async context =>
            {
                await context.Response.WriteAsync("Route {controller}");
            });
            route.MapRoute("{controller}/{action}", async context =>
            {
                await context.Response.WriteAsync("Route {controller}/{action}");
            });
            route.MapRoute("{controller}/{action}/{id?}", async context =>
            {
                await context.Response.WriteAsync("Route {controller}/{action}/{id?}");
            });
            app.UseRouter(route.Build());
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Default page");
            });
        }
    }
}
