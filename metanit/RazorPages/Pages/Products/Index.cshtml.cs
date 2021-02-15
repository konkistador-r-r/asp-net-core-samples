using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Products
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnGetRedirectToCreate()
        {
            return RedirectToPage("Edit");
            //Page(string pageName, string pageHandler, object values);
            //Page(string pageName, object values);
            //Page(string pageName, string pageHandler);
            //Page(string pageName);
        }

        public IActionResult OnGetRedirectToEdit()
        {
            //string url = Url.Page("Edit", new { Id = Guid.NewGuid(), Name = "Table" });
            //return Redirect(url);
            return RedirectToPage("Edit", new { Id = Guid.NewGuid(), Name = "Table" });
        }
    }
}