using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;

namespace RazorPages.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;

        [BindProperty]
        public Person Person { get; set; }
        public CreateModel(ApplicationContext context) {
            _context = context;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync() {
            if (ModelState.IsValid)
            {
                _context.People.Add(Person);
                await _context.SaveChangesAsync();
                
                // back to List page
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}