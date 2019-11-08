using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TestController : Controller
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
            return View(m);
        }

        [HttpPost]
        public IActionResult Index(ViewModel.TestView.TestViewModel vm)
        {
            var count = vm.Checkboxes.Count(v => v.Checked);
            return Content(count.ToString());
        }
    }
}