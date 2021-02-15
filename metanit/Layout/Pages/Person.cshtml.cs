using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layout.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Layout.Pages
{
    public class PersonModel : PageModel
    {
        // Самый простой способ получения данных - использование параметров в методах OnGet/OnPost/OnPut/OnDelete
        // мы можем также использовать и другой способ, который представляет применение атрибута BindProperty.
        public string Message { get; set; }

        // Однако поскольку оба свойства представляют фактически одну сущность, то естественно лучше работать с ними, как со свойствами одного объекта.
        //[BindProperty(SupportsGet = true)]
        //public string Name { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public int Age { get; set; }

        [BindProperty(SupportsGet = true)]
        public Person Person { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Person.Name) && !Person.Age.Equals(int.MinValue))
            {
                Message = $"Имя: {Person.Name}  Возраст: {Person.Age}";
                return;
            }

            var userid = RouteData.Values["id"];

            Message = "Введите данные";
        }
        public void OnPost() // string name, int age
        {
            //Message = $"Имя: {name}  Возраст: {age}";
            Message = $"Имя: {Person.Name}  Возраст: {Person.Age}";
        }
    }
}