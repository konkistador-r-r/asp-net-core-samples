using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        List<Contact> contact;
        public Contact FoundContact;
        public List<Contact> DisplayedContact { get; set; }

        public IndexModel()
        {
            contact = new List<Contact>()
            {
                new Contact {Name="Tom", Age=23},
                new Contact {Name = "Sam", Age=25},
                new Contact {Name="Bob", Age=23},
                new Contact {Name="Tom", Age=25}
            };
        }

        public void OnGet()
        {
            DisplayedContact = contact;
        }
        public void OnGetByName(string name)
        {
            DisplayedContact = contact.Where(p => p.Name.Contains(name)).ToList();
        }
        public void OnGetByAge(int age)
        {
            DisplayedContact = contact.Where(p => p.Age == age).ToList();
        }
        public IActionResult OnGetContactByName(string name)
        {
            this.FoundContact = contact.FirstOrDefault(p => p.Name == name);
            if (this.FoundContact == null)
                return NotFound("Такого пользователя не существует");

            DisplayedContact = contact; // do all page initialization as OnGet()
            return Page();
        }

        public void OnPostGreaterThan(int age)
        {
            DisplayedContact = contact.Where(p => p.Age > age).ToList();
        }
        public void OnPostLessThan(int age)
        {
            DisplayedContact = contact.Where(p => p.Age < age).ToList();
        }
    }
}