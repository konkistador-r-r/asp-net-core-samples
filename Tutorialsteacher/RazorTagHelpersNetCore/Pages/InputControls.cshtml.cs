using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTagHelpersNetCore.Pages
{
    public class InputControlsModel : PageModel
    {
        public string MovieName;
        public string PostedValue;
        public void OnGet()
        {
            MovieName = "Ghostbusters";
        }

        public void OnPost() {
            // restore the input value
            MovieName = Request.Form["MovieName"];
            // use input value
            PostedValue = Request.Form["MovieName"];
        }
    }
}