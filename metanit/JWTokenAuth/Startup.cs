using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTokenAuth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace JWTokenAuth
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Общие подходы к авторизации и аутентификации в ASP.NET Core Web API несколько отличаются от того, что мы имеем в MVC. 
            // В частности, в Web API механизм авторизации полагается преимущественно на JWT-токены.
            // JWT (или JSON Web Token) представляет собой веб-стандарт, который определяет способ передачи данных о пользователе в формате JSON в зашифрованном виде.
            // JWT-токен состоит из трех частей:
            // Header - объект JSON, который содержит информацию о типе токена и алгоритме его шифрования
            // Payload - объект JSON, который содержит данные, нужные для авторизации пользователя
            // Signature - строка, которая создается с помощью секретного кода, Headera и Payload. Эта строка служит для верификации токена

            // Для встраивания функциональности JWT-токенов в конвейер обработки запроса используется компонент JwtBearerAuthenticationMiddleware.

            // установкa аутентификации с помощью токенов
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        // конфигурация токена
                        // если равно false, то SSL при отправке токена не используется. 
                        // Однако данный вариант установлен только дя тестирования. В реальном приложении все же лучше использовать передачу данных по протоколу https.
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,

                            // можно установить название claims для ролей и логинов пользователя и т.д.
                        };
                    });

            // Теперь мы можем использовать авторизацию на основе токенов. 
            // Однако в прокте пока не предусмотрена генерация токенов. 
            // По умолчанию в ASP.NET Core отсутствуют встроенные возможности для создания токена.
            // И в данном случае мы можем либо воспользоваться сторонними решениями (например, IdentityServer или OpenIdDict), 
            // либо же создать свой механизм. Выберем второй способ.

            // add web api
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // to be able use index.html
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting(); 
            
            // enable auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // enable webapi
                endpoints.MapDefaultControllerRoute();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
