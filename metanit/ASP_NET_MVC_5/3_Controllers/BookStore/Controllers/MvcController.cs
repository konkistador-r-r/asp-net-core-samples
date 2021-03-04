using BookStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class MvcController : Controller
    {
        public ContentResult Square(int a = 10, int h = 3)
        {
            double s = a * h / 2.0;
            return Content("<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s + "</h2>");
        }

        public string Square2()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2.0;
            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult GetImage()
        {
            string path = Url.Content("~/Content/Images/Visual-Studio-Logo.png");
            return new ImageResult(path);
        }

        public ViewResult SomeMethod()
        {
            //ViewBag.Message = "Your contact page.";
            //ViewData["Message"] = "Your contact page.";
            TempData["Message"] = "Your contact page.";
            return View("~/Views/Home/Contact.cshtml");
        }
    }
}