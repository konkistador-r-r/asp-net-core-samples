using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmptyWebApplication
{
    // ѕри запуске приложени€ сначала срабатывает конструктор
    // затем метод ConfigureServices() 
    // и в конце метод Configure(). 
    // Ёти методы вызываютс€ средой выполнени€ ASP.NET.
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // в принципе в метод Configure в качестве параметра может передаватьс€ любой сервис, 
        // который зарегистрирован в методе ConfigureServices или который регистрируетс€ дл€ приложени€ по умолчанию (например, IWebHostEnvironment).
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage(); //  омпонент обработки ошибок - Diagnostics
            }

            // добавл€ем возможности маршрутизации
            app.UseRouting(); //  омпонент маршрутизации - EndpointRoutingMiddleware

            // устанавливаем адреса, которые будут обрабатыватьс€
            app.UseEndpoints(endpoints => //  омпонент EndpointMiddleware
            {
                // обработка запроса - получаем констекст запроса в виде объекта context
                endpoints.MapGet("/", async context =>
                {
                    // отправка ответа в виде строки "Hello World!"
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
