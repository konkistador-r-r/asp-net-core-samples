using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModel.Controls;
using Web.ViewModel.TestView;

namespace Web.ViewModel.TestView
{
    public class TestViewModel
    {
        [AtLeastOneRequired(ErrorMessage = "Please check at least one checkbox.")]
        public List<CheckboxModel> Checkboxes { get; set; }
    }
}
