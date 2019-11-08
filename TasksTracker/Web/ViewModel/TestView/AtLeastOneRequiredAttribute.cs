using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModel.TestView;

namespace Web.ViewModel.TestView
{
    public class AtLeastOneRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            // // ? context.ObjectType
            var vm = (TestViewModel)context.ObjectInstance;
            if (vm.Checkboxes.Any(v => v.Checked))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
