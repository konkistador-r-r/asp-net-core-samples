using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreIdentityFromScratch.Models
{
    public class CustomPasswordValidator : IPasswordValidator<User>
    {
        public int RequiredLength { get; set; } // минимальная длина
        public bool RequireNumbersOnly { get; set; }

        public CustomPasswordValidator(int length, bool numberrOnly = false)
        {
            RequiredLength = length;
            RequireNumbersOnly = numberrOnly;
        }

        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Минимальная длина пароля равна {RequiredLength}"
                });
            }

            if (RequireNumbersOnly)
            {
                string pattern = "^[0-9]+$";
                if (!Regex.IsMatch(password, pattern))
                {
                    errors.Add(new IdentityError
                    {
                        Description = "Пароль должен состоять только из цифр"
                    });
                }
            }

            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
