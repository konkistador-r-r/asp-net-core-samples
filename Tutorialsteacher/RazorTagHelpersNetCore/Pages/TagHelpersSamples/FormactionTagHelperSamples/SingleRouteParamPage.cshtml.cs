using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples
{
    public class SingleRouteParamPageModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public int SingleParam { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var postedName = Name;
        }

        public void OnPostSomePageHandler() {
            var postedName = Name;
        }
    }
}
