using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace RazorTagHelpersNetCore.Pages.TagHelpersSamples
{
    public enum Seniority { 
        None = 0,
        Junior = 1,
        Middle = 2,
        Senior = 3
    }
    public class Member
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        [Url]
        public string Website { get; set; }
        [Display(Name = "Send spam to me")]
        public bool SendSpam { get; set; }
        public int? NumberOfCats { get; set; }
        public IFormFile Selfie { get; set; }
    }
    public class HtmlHelperInputSampleModel : PageModel
    {
        [BindProperty]
        public Member Member { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool HasPhoto { get; set; }
        public Seniority SeniorityEnum { get; set; }
        public DateTime DateOfBirth { get; set; }


        public void OnGet()
        {

        }

        public void OnPost()
        {
            
        }
    }
}