using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample
{
    public class FormPageModel : PageModel
    {
        [BindProperty] // , TempData - any posted form value that is bound to the property will be overwritten by whatever is in TempData
        public string EmailAddress { get; set; }

        [TempData]
        public string FormResult { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                var contact = new Employee { FullName = "Mike", OfficePosition = "learnrazorpages.com" };
                TempData.Set("Mike", contact);
                var mike = TempData.Get<Employee>("Mike");

                var email = new MailAddress(EmailAddress);
                // If you need to assign a model bound value to TempData, remove the TempData attribute and make the assignation manually
                TempData["EmailAddress"] = EmailAddress;
                FormResult = "You have provided a valid email address";
                return RedirectToPage("/StateManagement/TempDataSample/FormSuccessPage");
            }
            catch (FormatException)
            {
                ModelState.AddModelError("EmailAddress", "Invalid email address");
                return Page();
            }
        }
    }
}