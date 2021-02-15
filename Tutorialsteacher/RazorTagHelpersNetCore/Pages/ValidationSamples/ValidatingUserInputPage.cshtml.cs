using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTagHelpersNetCore.Pages.StateManagement;

namespace RazorTagHelpersNetCore.Pages.ValidationSamples
{
    public class ValidatingUserInputPageModel : PageModel
    {
        [BindProperty]
        public Guid ContactId { get; set; }

        [BindProperty]
        [Required]
        [MinLength(6, ErrorMessage = "Name length must be more than 5 symbols")]
        public string Name { get; set; }

        public void OnGet()
        {
            var contactId = Guid.NewGuid();
            HttpContext.Session.SetString("ValidatingUserInputPageModel.ContactId", contactId.ToString());
            ContactId = contactId;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();                
            }


            if (!CustomServerSideValidation())
            {
                ModelState.AddModelError("ValidatingUserInputPageModel.ContactId", "ContactId is different from the original");
                return Page();
            }

            // do something
            return RedirectToPage();
        }

        private bool CustomServerSideValidation() {
            var contactIdStr = HttpContext.Session.GetString("ValidatingUserInputPageModel.ContactId");
            Guid contactId = Guid.Empty;
            Guid.TryParse(contactIdStr, out contactId);
            return contactId == ContactId;
        }
    }
}
