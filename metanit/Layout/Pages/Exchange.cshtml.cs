using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Layout.Pages
{
    public class ExchangeModel : PageModel
    {
        // get, post, put и т.д
        // Get обрабатывается методами OnGet() и OnGetAsync(), 
        // а запросы Post - методами OnPost() и OnPostAsync()

        public string Message { get; set; }
        private readonly decimal currentRate = 24.56m;


        public void OnGet()
        {
            Message = "Введите сумму";
        }

        public void OnPost(int? sum) {
            if (sum == null || sum < 1000)
            {
                Message = "Передана некорректная сумма. Повторите ввод";
            }
            else
            {
                decimal result = sum.Value / currentRate;
                // ToString("F2") - форматирование числа: F2 - дробное число с 2 знаками после запятой
                Message = $"При обмене {sum} UAH вы получите {result.ToString("F2")} USD.";
            }
        }
    }
}