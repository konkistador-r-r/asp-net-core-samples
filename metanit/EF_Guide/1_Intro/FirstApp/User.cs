using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    // Entity Framework требует определения ключа элемента для создания первичного ключа в таблице в бд. 
    // По умолчанию при генерации бд EF в качестве первичных ключей будет рассматривать свойства с именами Id или [Имя_класса]Id (то есть UserId).
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }    // Новое свойство - должность пользовател
    }
}
