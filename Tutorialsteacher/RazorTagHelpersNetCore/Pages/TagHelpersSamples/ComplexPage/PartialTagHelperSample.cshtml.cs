using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTagHelpersNetCore.Pages.TagHelpersSamples.ComplexPage;
using Microsoft.AspNetCore.Http;
using RazorTagHelpersNetCore.Pages.StateManagement;

namespace RazorTagHelpersNetCore.Pages.TagHelpersSamples
{
    public class PartialTagHelperSampleModel : PageModel
    {
        public List<Product> Products { 
            get { return HttpContext.Session.Get<List<Product>>("PartialTagHelperSampleModel.Products"); }
            set { HttpContext.Session.Set<List<Product>>("PartialTagHelperSampleModel.Products", value);  } 
        }

        public Product Product { get; set; }

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Number = 1,
                    Name = "Test product 1",
                    Description = "This is a test product"
                },
                new Product
                {
                    Number = 2,
                    Name = "Test product 2",
                    Description = "This is another test product"
                }
            };

            Product = new Product
            {
                Number = 1,
                Name = "Test product",
                Description = "This is a test product"
            };
        }

        public PartialViewResult OnGetProductsPartial(int number, string name, string description)
        {
            return ReturnProducts();
        }

        public PartialViewResult OnGetAddProductPartial(int number, string name, string description)
        {
            var newProduct = new Product { Number = number, Name = name, Description = description };
            
            var products = Products;
            products.Add(newProduct);
            Products = products;

            return ReturnProducts();
        }

        private PartialViewResult ReturnProducts() {
            return Partial("TagHelpersSamples/ComplexPage/_ProductsTablePartialView", Products);
        }
    }
}
