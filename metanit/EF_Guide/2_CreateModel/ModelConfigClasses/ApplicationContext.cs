using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelConfigClasses
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=mobileappdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // move code to IEntityTypeConfiguration classes
            // ProductConfiguration
            //modelBuilder.Entity<Product>()
            //        .ToTable("Mobiles").HasKey(p => p.Ident);
            //modelBuilder.Entity<Product>()
            //        .Property(p => p.Name).IsRequired().HasMaxLength(30);

            // CompanyConfiguration
            //modelBuilder.Entity<Company>().ToTable("Manufacturers")
            //        .Property(c => c.Name).IsRequired().HasMaxLength(30);

            // create classes instance
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            // or by method
            //modelBuilder.Entity<Product>(ProductConfigure);
            //modelBuilder.Entity<Company>(CompanyConfigure);

            // Инициализация БД начальными данными
            modelBuilder.Entity<User>().HasData(
            new User[]
            {
                new User { Id=1, Name="Tom", Age=23},
                new User { Id=2, Name="Alice", Age=26},
                new User { Id=3, Name="Sam", Age=28}
            });
            // Инициализация начальными данными будет выполняться только в двух случаях:
            // При выполнении миграции. (При создании миграции добавляемые данные автоматически включаются в скрипт миграции)
            // При вызове метода Database.EnsureCreated(), который создает БД при ее отсутствии
        }

        // or by method
        public void ProductConfigure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Mobiles").HasKey(p => p.Ident);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
        public void CompanyConfigure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Manufacturers").Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public Company()
        {
            Products = new List<Product>();
        }
    }

    public class Product
    {
        public int Ident { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Mobiles").HasKey(p => p.Ident);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
    }
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Manufacturers").Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
