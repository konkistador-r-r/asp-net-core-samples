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
            // ����� ������� � ����������� � �������������� � ASP.NET Core Web API ��������� ���������� �� ����, ��� �� ����� � MVC. 
            // � ���������, � Web API �������� ����������� ���������� ��������������� �� JWT-������.
            // JWT (��� JSON Web Token) ������������ ����� ���-��������, ������� ���������� ������ �������� ������ � ������������ � ������� JSON � ������������� ����.
            // JWT-����� ������� �� ���� ������:
            // Header - ������ JSON, ������� �������� ���������� � ���� ������ � ��������� ��� ����������
            // Payload - ������ JSON, ������� �������� ������, ������ ��� ����������� ������������
            // Signature - ������, ������� ��������� � ������� ���������� ����, Headera � Payload. ��� ������ ������ ��� ����������� ������

            // ��� ����������� ���������������� JWT-������� � �������� ��������� ������� ������������ ��������� JwtBearerAuthenticationMiddleware.

            // ��������a �������������� � ������� �������
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        // ������������ ������
                        // ���� ����� false, �� SSL ��� �������� ������ �� ������������. 
                        // ������ ������ ������� ���������� ������ �� ������������. � �������� ���������� ��� �� ����� ������������ �������� ������ �� ��������� https.
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // ��������, ����� �� �������������� �������� ��� ��������� ������
                            ValidateIssuer = true,
                            // ������, �������������� ��������
                            ValidIssuer = AuthOptions.ISSUER,

                            // ����� �� �������������� ����������� ������
                            ValidateAudience = true,
                            // ��������� ����������� ������
                            ValidAudience = AuthOptions.AUDIENCE,
                            // ����� �� �������������� ����� �������������
                            ValidateLifetime = true,

                            // ��������� ����� ������������
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // ��������� ����� ������������
                            ValidateIssuerSigningKey = true,

                            // ����� ���������� �������� claims ��� ����� � ������� ������������ � �.�.
                        };
                    });

            // ������ �� ����� ������������ ����������� �� ������ �������. 
            // ������ � ������ ���� �� ������������� ��������� �������. 
            // �� ��������� � ASP.NET Core ����������� ���������� ����������� ��� �������� ������.
            // � � ������ ������ �� ����� ���� ��������������� ���������� ��������� (��������, IdentityServer ��� OpenIdDict), 
            // ���� �� ������� ���� ��������. ������� ������ ������.

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
