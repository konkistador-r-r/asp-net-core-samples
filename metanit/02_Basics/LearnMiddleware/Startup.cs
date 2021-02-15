using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LearnMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                // следующая обработка запроса не рекомендуется, но как по другому - пока не понятно
                await context.Response.WriteAsync("Middleware 1\r\n");
                await next.Invoke(); // go to next middleware
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 2 Before\r\n");

                // выполнение такого компонента фактически делится на две части: до next.Invoke() и после next.Invoke()
                await next.Invoke(); // go to next middleware

                await context.Response.WriteAsync("Middleware 2 After\r\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 3 Before\r\n");
                await next.Invoke(); // go to next middleware
                await context.Response.WriteAsync("Middleware 3 After\r\n");
            });

            // delegate Task RequestDelegate(HttpContext context);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Middleware Last\r\n");
            });
        }
    }
}
