using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    public class ApplicationContext : DbContext
    {
        // Свойство DbSet представляет собой коллекцию объектов, которая сопоставляется с определенной таблицей в базе данных.
        public DbSet<User> Users { get; set; }

        // Через параметр options в конструктор контекста данных будут передаваться настройки контекста.
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            // В конструкторе с помощью вызова Database.EnsureCreated() будет создаваться база данных (если она отсутствует).
            Database.EnsureCreated();
        }
    }
}
