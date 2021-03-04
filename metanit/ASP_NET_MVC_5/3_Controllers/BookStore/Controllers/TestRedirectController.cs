using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class TestRedirectController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult TestRedirect(int id)
        {
            if (id == 1)
            {
                // Для временной переадресации
                return Redirect("/Home/Index"); // Code: 302
            }
            else {
                return Redirect("/Home/Contact");
            }            
        }

        public RedirectResult TestRedirectPermanent(int id)
        {
            // Выполняя запросы последовательно:
            // TestRedirect?id=1 => /Home/Index
            // TestRedirect?id=2 => /Home/Index - потому что Permanent
            if (id == 1)
            {
                // Для постоянной переадресации 
                // данный способ использовать нежелательно
                return RedirectPermanent("/Home/Index"); // Code: 301
            }
            else
            {
                // 
                return RedirectPermanent("/Home/Contact");
            }
        }

        public RedirectToRouteResult TestRedirectToRoute()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public RedirectToRouteResult TestRedirectToAction()
        {
            return RedirectToAction("Square", "Home", new { a = 10, h = 12 });
        }

        public ActionResult CheckAge(int age)
        {
            if (age <= 0)
            {
                return HttpNotFound();
            }
            if (age > 0 && age <= 21)
            {
                return new HttpStatusCodeResult(404);
            }
            if (age > 21 && age <= 31)
            {
                return new HttpUnauthorizedResult();
            }
            return Content("Content");
        }
    }
}