using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample
{
    public class FormSuccessPageModel : PageModel
    {
        //[BindProperty, TempData] // any posted form value that is bound to the property will be overwritten by whatever is in TempData
        //[BindProperty]
        public string EmailAddress { get; set; }
        //[TempData]
        public string FormResult { get; set; } // Name must much

        public void OnGet()
        {
            // Retaining TempData Values
            // Make possible to access after page refresh, but NOT on this page
            //TempData.Keep("EmailAddress");
            //TempData.Keep("FormResult");

            // or whole Dictionary 
            //TempData.Keep();

            // or comment TempData attr
            object o = TempData.Peek("FormResult");
            FormResult = o == null ? string.Empty : (string)o;
            o = TempData.Peek("EmailAddress");
            EmailAddress = o == null ? string.Empty : (string)o;
        }
    }
}