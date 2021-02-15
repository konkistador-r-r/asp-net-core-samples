using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SortFilterPagingApp.Models;

namespace SortFilterPagingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsersContext _db;

        public HomeController(ILogger<HomeController> logger, UsersContext context)
        {
            _logger = logger;
            _db = context;

            // добавим начальные данные для тестирования
            if (_db.Companies.Count() == 0)
            {
                AddDataForTestingPurpose(_db);
            }
        }

        // Итак, нам надо произвести три операции: фильтрацию, сортировку и пагинацию. 
        // Каждая из этих операций будет представлять свой набор параметров. 
        // Для упрощения для каждого набора параметров определим собственную модель. 
        public async Task<IActionResult> Index(int? company, string name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            // Фильтрация ни от чего не зависит. Сортировка зависит от фильтрации. А пагинация зависит от фильтрации и сортировки. 
            // Поэтому сначала надо выполнить фильтрацию, потом сортировку и в конце пагинацию.
            int pageSize = 3;

            //фильтрация
            IQueryable<User> users = _db.Users.Include(x => x.Company);

            if (company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case SortState.CompanyAsc:
                    users = users.OrderBy(s => s.Company.Name);
                    break;
                case SortState.CompanyDesc:
                    users = users.OrderByDescending(s => s.Company.Name);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_db.Companies.ToList(), company, name),
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
