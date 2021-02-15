using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DbFirst
{
    public partial class ApplicationContext : DbContext
    {
        private IConfigurationRoot Configuration;
        public ApplicationContext()
        {
            Configuration = GetConfiguration();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                // Чтобы использовать connectionString  из файла конфигурации необходимо добавить в проект через Nuget пакеты: 
                // Microsoft.Extensions.Configuration, Microsoft.Extensions.Configuration.Json
                // Добавить файл appsettings.json и в него connectionString
                // Установить св-во Copy to Output directory: Copy if newer

                // установка логгирования глобально для всех операций контекста
                //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            }
        }
        // устанавливаем фабрику логгера
        // Чтобы установить провайдер логгирования, нам нужна фабрика логгера - объект ILoggerFactory. 
        // Для этого определяем статическую переменную MyLoggerFactory, которой присваивается результат метода LoggerFactory.Create. 
        // Данный метод устанавливает для использования ранее созданный провайдер MyLoggerProvider.
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            // с более детальной настройкой логгирования: https://metanit.com/sharp/entityframeworkcore/2.12.php
            //builder
            //    .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name)
            //    .AddProvider(new MyLoggerProvider());    // указываем наш провайдер логгирования
            // Database.Command: категория для выполняемых команд, позволяет получить выполняемый код SQL

            // Использование встроенног провайдера: Microsoft.Extensions.Logging.Console
            builder.AddConsole();
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private IConfigurationRoot GetConfiguration() {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();

            return config;
        }
    }
}
