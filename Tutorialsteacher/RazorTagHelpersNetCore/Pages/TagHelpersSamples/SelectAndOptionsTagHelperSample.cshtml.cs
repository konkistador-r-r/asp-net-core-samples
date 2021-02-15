using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorTagHelpersNetCore.Pages.TagHelpersSamples
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectAndOptionsTagHelperSampleModel : PageModel
    {
        #region The first example shows a default option manually added to the select tag helper.
        public List<SelectListItem> Items =>
            Enumerable.Range(1, 3).Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            }).ToList();
        public int Number { get; set; }
        #endregion

        #region The second example shows a number of options manually added to the select tag helper, one of which matches the value of the for attribute property.
        public int Number2 { get; set; } = 2;
        #endregion

        #region Custom sample
        public List<SelectListItem> Items2 =>
            Enumerable.Range(0, 3).Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            }).ToList();
        public int Number3 { get; set; }
        #endregion

        #region List of entity sample
        [BindProperty]
        public int Person { get; set; }
        public List<Person> People { get; set; }
        #endregion

        #region Multiple-select for list of entity sample
        [BindProperty]
        public List<int> Persons { get; set; }
        #endregion

        #region Set list item sample
        // The SelectListItem type has a boolean property named Selected. This can be used to set the selected item unless you specify a property for the asp-for attribute. I
        // [BindProperty] public int CarSelected { get; set; }
        public List<SelectListItem> CarsList { get; set; }
        #endregion

        #region an enumeration as the data source for a select list
        public DayOfWeek? DayOfWeek { get; set; }
        #endregion

        #region create a SelectList from any collection
        [BindProperty]
        public int EntityKey { get; set; }
        public SelectList EntityOptions { get; set; }
        #endregion

        #region SelectListGroup sample
        [BindProperty]
        public int Employee { get; set; }
        public List<SelectListItem> Staff { get; set; }
        #endregion

        public void OnGet()
        {
            People = new List<Person> {
                new Person { Id = 1, Name="Mike" },
                new Person { Id = 2, Name="Pete" },
                new Person { Id = 3, Name="Katy" },
                new Person { Id = 4, Name="Carl" }
            };

            // Set list item sample
            Person = 3;
            // Multiple-select
            Persons = new List<int> { 2, 3 };
            CarsList = new List<SelectListItem> {
                new SelectListItem { Value = "1", Text = "BMW" },
                new SelectListItem { Value = "2", Text = "Audi" },
                new SelectListItem { Value = "3", Text = "Mazda", Selected = true },
                new SelectListItem { Value = "4", Text = "Nissan" }
            };

            // create a SelectList from any collection
            var entityAsDict = People.Select(p => new KeyValuePair<int, string>(p.Id, p.Name)).ToDictionary(p => p.Key, v => v.Value);
            EntityOptions = new SelectList(entityAsDict, "Key", "Value");
            EntityKey = 2;

            // SelectListGroup sample
            Employee = 2;
            var salesGroup = new SelectListGroup { Name = "Sales" };
            var adminGroup = new SelectListGroup { Name = "Admin" };
            var itGroup = new SelectListGroup { Name = "IT" };
            Staff = new List<SelectListItem>
            {
                new SelectListItem{ Value = "1", Text = "Mike", Group = itGroup},
                new SelectListItem{ Value = "2", Text = "Pete", Group = salesGroup},
                new SelectListItem{ Value = "3", Text = "Katy", Group = adminGroup},
                new SelectListItem{ Value = "4", Text = "Carl", Group = salesGroup}
            };
            // or set Group prop in SelectList constructor like
            // In the example above, the nameof operator is used to minimise the chances of typos creeping into the code.
            //Staff = new SelectList(People, nameof(Person.Id), nameof(Person.Name), null, nameof(Person.Department));
        }
    }
}
