using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeneratePrimaryKeyValue
{
    // По умолчанию для свойств первичных ключей, которые представляют типы int или GUID и которые имеют значение по умолчанию,
    // генерируется значение при вставке в базу данных

    // Для свойств, которые не представляют ключи и для которых не устанавливается значения, используются значения по умолчанию. 
    // Например, для свойств типа int это значение 0.

    // По умолчанию свойство является необязательным к установке, если оно допускает значение null. 
    // Это свойства, которые имеют, например, такие типы как string, int?, byte[], объекты классов и т.д. 
    // Хотя мы также можем настроить эти свойства как обязательные.
    public class User
    {
        // Если мы хотим, чтобы база данных, наоборот, сама генерировала значение, то в атрибут надо передавать значение
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // отключить автогенерацию значения при добавлении
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(255)] // nvarchar(255)
        [Required] // NOT NULL
        public string Name { get; set; }
        [MinLength(4)] // устанавливает минимальную длину, но он на определение таблицы не влияет. ???
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GeneratePrimaryKeyValueDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Отключение автогенерации значения для свойства
            // modelBuilder.Entity<User>().Property(b => b.Id).ValueGeneratedNever();

            // Значения по умолчанию
            // В этом случае, если мы не укажем значение для свойства Age, то ему будет присвоено значение 18
            modelBuilder.Entity<User>().Property(u => u.Age).HasDefaultValue(18);
            // Метод HasDefaultValueSql() также определяет генерацию значения по умолчанию, 
            // только само значение устанавливается на основе кода SQL, который передается в этот метод.
            // В метод HasDefaultValueSql() передается SQL-выражение, которые вызывается при добавлении объекта User в базу данных
            modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

            // Столбцы могут иметь значение, которое вычисляется на основании остальных столбцов. Например, пусть модель User имеет свойства для хранения имени и фамилии:
            modelBuilder.Entity<User>().Property(u => u.Name).HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            // modelBuilder.Entity<User>().Property(b => b.Name).IsRequired();

            // modelBuilder.Entity<User>().Property(u=>u.FirstName).HasColumnType("nvarchar(200)");
        }
    }
}
