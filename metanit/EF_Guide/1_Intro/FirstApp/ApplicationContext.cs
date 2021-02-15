using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    // DbContext: определяет контекст данных, используемый для взаимодействия с базой данных
    public class ApplicationContext : DbContext
    {
        // DbSet/DbSet<TEntity>: представляет набор объектов, которые хранятся в базе данных
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            // Database.EnsureDeleted();   // удаляем бд со старой схемой
            // Database.EnsureCreated();   // создаем бд с новой схемой
        }

        // DbContextOptionsBuilder: устанавливает параметры подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFFirstApp;Trusted_Connection=True;");
        }
    }
}
