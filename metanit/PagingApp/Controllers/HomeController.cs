using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagingApp.Models;

namespace PagingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsersContext _db;

        public HomeController(ILogger<HomeController> logger, UsersContext db)
        {
            _logger = logger;
            _db = db;

            // добавим начальные данные для тестирования
            if (_db.Companies.Count() == 0)
            {
                AddDataForTestingPurpose(_db);
            }
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице

            // с помощью метода Skip() пропускаем нужное количество элементов, чтобы достичь нужной страницы.И с помощью метода Take() выбираем нужную порцию элементов, которая равна размеру страницы.
            // создание и выполнение 2х запросов: всего эл и страница элементов
            IQueryable<User> source = _db.Users.Include(x => x.Company);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Users = items
            };
            return View(viewModel);
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

        private void AddDataForTestingPurpose(UsersContext db)
        {
            Company oracle = new Company { Name = "Oracle" };
            Company google = new Company { Name = "Google" };
            Company microsoft = new Company { Name = "Microsoft" };
            Company apple = new Company { Name = "Apple" };

            User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
            User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
            User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
            User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
            User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
            User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
            User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
            User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

            db.Companies.AddRange(oracle, microsoft, google, apple);
            db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
            db.SaveChanges();
        }
    }
}
