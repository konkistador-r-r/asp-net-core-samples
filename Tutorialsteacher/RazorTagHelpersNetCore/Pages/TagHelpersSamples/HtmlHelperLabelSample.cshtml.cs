using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorTagHelpersNetCore.Pages.TagHelpersSamples
{
    public class HtmlHelperLabelSampleModel : PageModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public void OnGet()
        {

        }
    }
}