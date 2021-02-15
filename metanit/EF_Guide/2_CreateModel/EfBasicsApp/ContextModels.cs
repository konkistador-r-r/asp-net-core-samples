using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfBasicsApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        // навигационное свойство
        public Company Manufacturer { get; set; }
        [NotMapped]
        public int Rate { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Если в контексте данных подобного свойства не определено, то для названия таблицы используется имя класса сущности.
    [Table("People")]
    public class User
    {
        // По умолчанию в качестве ключа используется свойство, которое называется Id или or [имя_класса]Id. 
        [Column("Ident")][Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
