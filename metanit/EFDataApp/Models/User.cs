using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    // Эта модель представляет те объекты, которые будут храниться в базе данных
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } // имя пользователя
        public int Age { get; set; } // возраст пользователя
    }
}
