using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIdentityFromScratch.Data;
using CoreIdentityFromScratch.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreIdentityFromScratch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ��������� ������ ���������� ������
            // ��������� ����������� ��� ���������� IPasswordValidator � ���� ������� CustomPasswordValidator.
            services.AddTransient<IPasswordValidator<User>, CustomPasswordValidator>(serv => new CustomPasswordValidator(6, true));
            services.AddTransient<IUserValidator<User>, CustomUserValidator>();

            // configure ef context
            services.AddDbContext<AppIdentityContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // specify which ef context will provide Identity data
            // ����� AddIdentity() ��������� ���������� ��������� ��������� ������������. 
            // ����� �� ��������� ��� ������������ � ��� ����, ������� ����� �������������� �������� Identity. 
            // � �������� ���� ������������ ��������� ��������� ���� ���� ����� User, 
            // � � �������� ���� ���� ���� ����������� ����� IdentityRole
            services.AddIdentity<Models.User, IdentityRole>(opts => {
                // � �������� �� ��, ��� ���������� ������ ��������� ������ �� ����� ����, �� �� ����� �������������� 
                // � ������� ������� Microsoft.AspNetCore.Identity.PasswordOptions.
                //  ������ ���� ��� ����������� ����� ������� ������ ���������, �� �������� ���������� ���� ����� ����������. (IPasswordValidator<T>)
                opts.Password.RequiredLength = 5;   // ����������� �����
                opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                opts.Password.RequireDigit = false; // ��������� �� �����

                // �� ��������� ������������ �� ��������� �������� ����� UserOptions, ������� ���������� ��������� ��������.
                // �� ����� ��������� �������������� ������ ���������, ������ ���� ����� ����������. (IUserValidator<T>)
                //opts.User.RequireUniqueEmail = true;    // ���������� email
                //opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // ���������� �������
            })
                .AddEntityFrameworkStores<AppIdentityContext>();

           

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // �����, ����� ������������ Identity, � ������ Configure() ��������������� ��������� middeware - UseAuthentication. 
            // ������ ��� middleware ���������� ����� app.UseEndpoints(), ��� ����� ����������, ��� �� ������� ��������� � ������� �������������, ������������ � �� �������, 
            // ���� ������� ������� ���������� � �����������.
            app.UseAuthentication();    // ����������� ��������������
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
