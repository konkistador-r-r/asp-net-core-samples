using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTagHelpersNetCore.Pages
{
    public class ModelBindingSamplesModel : PageModel
    {
        public void OnGet()
        {

        }

        // 1. When the form is completed and submitted, the values are sent in the request body in name/value pairs, 
        // where the "name" represents the name attribute of the input
        //public void OnPost()
        //{
        //    var name = Request.Form["Name"];
        //    var email = Request.Form["Email"];
        //    ViewData["confirmation"] = $"{name}, information will be sent to {email}";
        //}

        // 2. Binding Posted Form Values To Handler Method Parameters link
        // This approach is suitable when the values are not needed outside of the handler method to which the parameters belong. 
        //public void OnPost(string name, string email)
        //{
        //    ViewData["confirmation"] = $"{name}, information will be sent to {email}";
        //}

        // 3. Binding Posted Form Values to PageModel Properties link
        // This approach is more suitable if you need to access the values outside of the handler method 
        // (for display on the page or binding to tag helpers, for example)
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(Name="e-m-a-i-l")] // 9. Binding to Arbitrary Keys
        public string Email { get; set; }
        public void OnPost()
        {
            var isValid = ModelState.IsValid;
            if (!isValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(er => er.ErrorMessage);
                ViewData["errorMessages"] = string.Join(",", allErrors);
                return;
            }
            ViewData["confirmation"] = $"{Name}, information about {ContactInfoForFields.Phone} " +
                $"and {ContactInfoForFields.Address} will be sent to {Email}" +
                $"You selected the following categories: {string.Join(",", MovieCategoryIds)}";
        }

        // 4. Binding Route Data
        [BindProperty(SupportsGet = true)]
        public string MyRouteParamName { get; set; }
        // https://localhost:44310/ModelBindingSamples/routeParamValue123/?Name=Stas

        // 5. Binding Complex Objects
        // https://localhost:44310/ModelBindingSamples/myRouteParamName?Phone=0668830091
        // or
        // https://localhost:44310/ModelBindingSamples/myRouteParamName?ContactInfoForFields.Phone=0668830091
        [BindProperty(SupportsGet = true)]
        public UserContactInfo ContactInfoForFields { get; set; }
        // or public void OnPost(UserContactInfo ContactInfoForFields)


        // 6. Binding Simple Collections - user is allowed to select more than one option.
        // ASP.NET Core type, which represents zero/null, one, or many strings. 
        //This can be converted by the model binder to an array of any type that the values can be converted to - strings or integers
        // Microsoft.Extensions.Primitives.StringValues
        // you can initiate the collection as part of its declaration
        [BindProperty(SupportsGet = true)]
        public int[] MovieCategoryIds { get; set; }// = new int[0];


        // 7. Binding Complex Collections
        [BindProperty]
        public List<Employee> NewEmployees { get; set; }
        [BindProperty]
        public List<Employee> EditEmployees { get; set; } = new List<Employee> {
            new Employee { EmployeeId = 1, FullName = "Vlasenko Stanislav", OfficePosition = "Investor" },
            new Employee { EmployeeId = 2, FullName = "Vlasenko Vladimir", OfficePosition = "Head of depertment" }
        };


        // 8. Binding Related Collections to a Complex Object link
        // When the form is posted back, the model binder will create an Order object, and an OrderItem object, 
        // which will be assigned to the OrderItems collection of the Order
        [BindProperty]
        public Order Order { get; set; }
    }

    // 5. Binding Complex Objects
    public class UserContactInfo {
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    // 7. Binding Complex Collections
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string OfficePosition { get; set; }
    }

    // 8. Binding Related Collections to a Complex Object link
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
    }
}