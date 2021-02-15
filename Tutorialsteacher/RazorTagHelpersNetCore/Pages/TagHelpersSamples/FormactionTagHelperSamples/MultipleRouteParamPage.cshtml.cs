using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples
{
    public class MultipleRouteParamPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Param1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Param2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            var postedName = Name;
        }
    }
}
