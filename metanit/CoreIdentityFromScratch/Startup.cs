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
            // ƒобавл€ем сервис валидатора парол€
            // добавл€ет зависимость дл€ интерфейса IPasswordValidator в виде объекта CustomPasswordValidator.
            services.AddTransient<IPasswordValidator<User>, CustomPasswordValidator>(serv => new CustomPasswordValidator(6, true));
            services.AddTransient<IUserValidator<User>, CustomUserValidator>();

            // configure ef context
            services.AddDbContext<AppIdentityContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // specify which ef context will provide Identity data
            // ћетод AddIdentity() позвол€ет установить некоторую начальную конфигурацию. 
            // «десь мы указываем тип пользовател€ и тип роли, которые будут использоватьс€ системой Identity. 
            // ¬ качестве типа пользовател€ выступает созданный нами выше класс User, 
            // а в качестве типа роли вз€т стандартный класс IdentityRole
            services.AddIdentity<Models.User, IdentityRole>(opts => {
                // » несмотр€ на то, что встроенна€ логика валидации скрыта от наших глаз, мы ее можем переопределить 
                // с помощью объекта Microsoft.AspNetCore.Identity.PasswordOptions.
                //  ќднако если нам потребуетс€ более сложна€ логика валидации, то придетс€ определ€ть свой класс валидатора. (IPasswordValidator<T>)
                opts.Password.RequiredLength = 5;   // минимальна€ длина
                opts.Password.RequireNonAlphanumeric = false;   // требуютс€ ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуютс€ ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуютс€ ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуютс€ ли цифры

                // «а валидацию пользовател€ по умолчанию отвечает класс UserOptions, который определ€ет следующие свойства.
                // мы можем полностью переопределить логику валидации, создав свой класс валидатора. (IUserValidator<T>)
                //opts.User.RequireUniqueEmail = true;    // уникальный email
                //opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
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

            // «атем, чтобы использовать Identity, в методе Configure() устанавливаетс€ компонент middeware - UseAuthentication. 
            // ѕричем это middleware вызываетс€ перед app.UseEndpoints(), тем самым гарантиру€, что ко времени обращени€ к системе маршрутизации, контроллерам и их методам, 
            // куки должным образом обработаны и установлены.
            app.UseAuthentication();    // подключение аутентификации
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
