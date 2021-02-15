using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTagHelpersNetCore.Pages
{
    public class PageHandlerMethodsModel : PageModel
    {
        public string Message { get; set; }
        public string Message2 { get; set; } = "Initial Request";
        public string Message3 { get; set; } = "Initial Request";

        // on load
        // В методе OnGet через параметры name и age мы можем получить переданные через строку запроса значения.
        // public void OnGet(string name, int? age)
        public void OnGet()
        {
            Message = "Get used";
        }

        // on post
        public void OnPost()
        {
            Message = "Post used";
        }

        // HTML forms don't support PUT, DELETE, etc.: only GET and POST. If you need to send a PUT, you'll need to use AJAX to do so.
        //// on put
        //public void OnPut()
        //{
        //    Message = "Put used";
        //}
        //// on post
        //public void OnDelete()
        //{
        //    Message = "Delete used";
        //}

        // Named Handler Methods - if your page features multiple forms
        // Do not work like this only POST
        //public void OnGetMyCustomHandler()
        //{
        //    Message = "MyCustomHandler used";
        //}
        public void OnPostMyCustomHandler()
        {
            Message = "MyCustomHandler used";
        }

        // Pass parameters
        public void OnPostEdit(bool myParamName)
        {
            Message2 = $"Post Edit used: {myParamName}";
        }
        public void OnPostDelete(string myParamName)
        {
            Message2 = $"Post Delete used: {myParamName}";
        }
        public void OnPostView(int id)
        {
            Message2 = $"Post View used: {id}";
        }

        // Handling Multiple Actions For The Same Form
        public async Task<IActionResult> OnPostRegisterAsync()
        {
            Message3 = $"Post Register used";
            return Page();
        }
        public async Task<IActionResult> OnPostRequestInfo()
        {
            Message3 = $"Post RequestInfo used";
            return Page();
        }
    }
}