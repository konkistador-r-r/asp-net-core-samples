using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    // Custom Validation Attribute
    
    // Checkbox Model
    
    // ViewModel
    


public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // add via dependency injection later
            //var dal = new TasksTrackerBLL.JobTaskDAL();

            //return View(dal.GetAllJobTask());
            var m = new ViewModel.TestView.TestViewModel();
            m.Checkboxes = new List<ViewModel.Controls.CheckboxModel>() { 
                new ViewModel.Controls.CheckboxModel { Text="Option 1", Value=1, Checked = false },
                new ViewModel.Controls.CheckboxModel { Text="Option 2", Value=2 },
                new ViewModel.Controls.CheckboxModel { Text="Option 3", Value=3 }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Index(ViewModel.TestView.TestViewModel vm) {
            var count = vm.Checkboxes.Count(v => v.Checked);
            return Content(count.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
