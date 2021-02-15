using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentityFromScratch.ViewModels
{
    /*
        При вводе пароля срабатывает встроенная логика, согласно которой 
        длина пароля не может быть меньше 6 символов, 
        пароль должен содержать как минимум один цифровой 
        и один не алфавитно-цифровой символ, 
        а также как минимум один алфавитный символ должен быть в верхнем регистре. 
        
        Но что, если нам надо установить другую минимальную длину пароля? 
        Или что если мы хотим, чтобы в пароле могли бы использоваться только цифровые или только алфавитные символы? 
    */
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Год рождения")]
        [Range(1917, 2020, ErrorMessage = "{0} вне диапазона {1} - {2}")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
