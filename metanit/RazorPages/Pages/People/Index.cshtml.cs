using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Person> People { get; set; }
        public IndexModel(ApplicationContext context) {
            _context = context;
        }
        public void OnGet()
        {
            People = _context.People.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id) {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}