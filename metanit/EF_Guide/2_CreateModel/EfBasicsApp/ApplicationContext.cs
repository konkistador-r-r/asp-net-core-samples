using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfBasicsApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем бд с новой схемой
        }

        // в базе данных будут созданы две таблицы: Products и Company, т.к. 
        // для типа Product определен набор DbSet, то для имени таблицы будет применяться имя этого набора, 
        // а для второй таблицы будет использоваться имя класса Company.
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=efbasicsappdb;Trusted_Connection=True;");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Еще один способ включения сущности в модель представляет вызов Entity() объекта ModelBuilder в методе OnModelCreating()
            modelBuilder.Entity<Country>();

            // допустим, мы не хотим, чтобы в базе данных была таблица Company
            // Аннотации данных предполагают установку над классом атрибута [NotMapped]
            // При исключении сущности Company в базе данных будет только одна таблица Products, причем она не будет содержать столбца, который бы сопоставлялся со свойством Manufacturer класса Product
            //modelBuilder.Ignore<Company>();

            // Иногда требуется, наоборот, исключить определенное свойство, чтобы для него не создавался столбец в таблице.
            // modelBuilder.Entity<Product>().Ignore(b => b.Rate);


            // modelBuilder.Entity<User>().ToTable("People");
            // С помощью дополнительного параметра schema можно определить схему, к которой будет принадлежать таблица:
            // modelBuilder.Entity<User>().ToTable("People", schema: "userstore");

            // modelBuilder.Entity<User>().Property(u=>u.Id).HasColumnName("user_id");

            // Составной ключ можно создать только с помощью Fluent API.
            // modelBuilder.Entity<User>().HasKey(u => u.Ident);
            // С помощью Fluent API можно создать составной ключ из нескольких свойств
            // modelBuilder.Entity<User>().HasKey(u => new { u.PassportSeria, u.PassportNumber});
            // Дополнительно с помощью Fluent API можно настроить имя ограничения, которое задается для первичного ключа. 
            // modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("UsersPrimaryKey");

            // Альтернативные ключи - для соответствующих столбцов ограничения на уникальность.
            // modelBuilder.Entity<User>().HasAlternateKey(u => u.Passport);
            // modelBuilder.Entity<User>().HasAlternateKey(u => new { u.Passport, u.PhoneNumber });

            // Для увеличения производительности поиска в базе данных применяются индексы.
            // По умолчанию индекс создается для каждого свойства, которое используется в качестве внешнего ключа.
            // modelBuilder.Entity<User>().HasIndex(u => u.Passport);
            // modelBuilder.Entity<User>().HasIndex(u => new { u.Passport, u.PhoneNumber });
            // Можно указать, что индекс должен иметь уникальное значение. 
            // Тем самым мы гарантируем, что в базе данных может быть только один объект с определенным значением для свойства-индекса
            // modelBuilder.Entity<User>().HasIndex(u => u.Passport).IsUnique();


        }
    }
}
