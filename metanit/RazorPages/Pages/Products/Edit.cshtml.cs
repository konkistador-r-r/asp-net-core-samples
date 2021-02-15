using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Products
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty(SupportsGet=true)]
        public string Name { get; set; }

        public string Message { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = Id.Equals(Guid.Empty) ? "Create Product" : "Edit Product";

            Message = Id.Equals(Guid.Empty) ? "нет данных" : $"данные by URL - Id: {Id} Name: {Name}";
        }
    }
}