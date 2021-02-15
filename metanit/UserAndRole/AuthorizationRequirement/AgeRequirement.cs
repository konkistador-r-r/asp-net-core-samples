using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAndRole.Models
{
    // Сам класс ограничения только устанавливает некоторые лимиты, больше он ничего не делает. 
    // Чтобы его использовать при обработке запроса, нам надо добавить специальный класс - обработчик.
    public class AgeRequirement : IAuthorizationRequirement
    {
        // С помощью свойства Age устанавливается минимально допустимый возраст.
        protected internal int Age { get; set; }

        public AgeRequirement(int age)
        {
            Age = age;
        }
    }
}
