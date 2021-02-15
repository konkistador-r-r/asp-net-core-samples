using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTagHelpersNetCore.Pages.ValidationSamples
{
    public class RemoteValidationSamplePage : PageModel
    {
        [BindProperty]
        public Guid ContactId { get; set; }

        // The property to be validated must be a direct descendent of the PageModel class (i.e. not a property of a child property of the PageModel, also referred to as a "nested property")
        // Contact.Email will not work
        [BindProperty]
        [Required]
        [MinLength(6, ErrorMessage = "Email length must be more than 5 symbols")]
        [PageRemote(
            ErrorMessage = "Email Address already exists",
            AdditionalFields = "__RequestVerificationToken",
            HttpMethod = "post",
            PageHandler = "CheckEmail"
        )]
        public string Email { get; set; }

        public void OnGet()
        {
            ContactId = Guid.NewGuid();
        }

        public JsonResult OnPostCheckEmail()
        {
            var existingEmails = new[] { "jane@test.com", "claire@test.com", "dave@test.com" };
            var valid = !existingEmails.Contains(Email);
            return new JsonResult(valid);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // do something
            return RedirectToPage();
        }
    }
}