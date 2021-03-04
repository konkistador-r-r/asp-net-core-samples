using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

        //public ActionResult Index()
        //{
        //    // получаем из бд все объекты Book
        //    IEnumerable<Book> books = db.Books;
        //    // передаем все объекты в динамическое свойство Books в ViewBag
        //    ViewBag.Books = books;
        //    // возвращаем представление
        //    return View();
        //}

        // асинхронный метод
        [ActionName("Index")]
        public async Task<ActionResult> BookList()
        {
            IEnumerable<Book> books = await db.Books.ToListAsync();
            ViewBag.Books = books;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            // Если в качестве параметра будет передано число больше 3, то произойдет редирект на Home/Index. 
            // В остальных случаях пользователю будет возвращаться представление.
            if (id > 3)
            {
                return Redirect("/Home/Index");
            }
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = GetToday();
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }
        private DateTime GetToday()
        {
            return DateTime.Now;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}