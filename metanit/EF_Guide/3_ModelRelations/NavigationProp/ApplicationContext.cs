using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NavigationProp
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } // название компании

        public List<User> Users { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public int CompanyId { get; set; }      // внешний ключ: может быть Nullable(int?) или нет
        //public int CompanyInfoKey { get; set; } // внешний ключ

        public string CompanyName { get; set; }
        //[ForeignKey("CompanyInfoKey")]
        public Company Company { get; set; }    // навигационное свойство
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Without Fluent API or ForeignKeyAttribute or correct naming <Entity>+<KeyColumn> (CompanyId)
            // error thrown 'Invalid column name 'CompanyId'. Invalid column name 'CompanyId'.'
            // Настройка внешнего ключа с помощью Fluent API
            //modelBuilder.Entity<User>()
            //    .HasOne(p => p.Company)
            //    .WithMany(t => t.Users)
            //    .HasForeignKey(p => p.CompanyInfoKey);

            // Кроме того, с помощью Fluent API мы можем связь внешнего ключа не только с первичными ключами связанных сущностей, но и с другими свойствами. Например:
            // Reference not by PK but by other columns, but now Company.Name have to be unique
            //modelBuilder.Entity<User>().Property(b => b.CompanyName).IsRequired();
            modelBuilder.Entity<User>()
                .HasOne(p => p.Company)
                .WithMany(t => t.Users)
                .HasForeignKey(p => p.CompanyName)
                .HasPrincipalKey(t => t.Name)
                .OnDelete(DeleteBehavior.Restrict);

            // Инициализация БД начальными данными
            modelBuilder.Entity<Company>().HasData(
            new User[]
            {
                new User { Id=1, Name="Microsoft"},
                new User { Id=2, Name="Google"}
            });
            modelBuilder.Entity<User>().HasData(
            new User[]
            {
                new User { Id=1, Name="Tom", CompanyName="Microsoft"},
                new User { Id=2, Name="Alice", CompanyName="Microsoft"},
                new User { Id=3, Name="Sam", CompanyName="Google"}
            });
        }
    }
}
