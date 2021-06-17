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

namespace _03_RoutingInfo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            RouteBuilder route = new(app);
            route.MapRoute("{controller}/{action}/{id}", async context =>
            {
                string controller = context.GetRouteValue("controller")?.ToString(),
                       action = context.GetRouteValue("action")?.ToString(),
                       id = context.GetRouteValue("id")?.ToString();
                await context.Response.WriteAsync($"<p>{controller}</p>");
                await context.Response.WriteAsync($"<p>{action}</p>");
                await context.Response.WriteAsync($"<p>{id}</p>");
            });
            app.UseRouter(route.Build());
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Default page");
            });
        }
    }
}
