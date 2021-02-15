using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Layout.Pages
{
    public class IndexModel : PageModel
    {
        // через свойство Model мы сможем обращаться к модели страницы, в том числе к ее свойствам.
        public string Name { get; set; }
        public int? Age { get; set; }
        public bool IsCorrect { get; set; } = true;

        // В методе OnGet через параметры name и age мы можем получить переданные через строку запроса значения.
        // параметр из строки запроса должен совпадать по названию с параметром метода OnGet - Index?name=Tom&age=35
        public void OnGet(string name, int? age)
        {
            if (age == null || age < 1 || age > 110 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }
                    
            Age = age;
            Name = name;
        }
    }
}