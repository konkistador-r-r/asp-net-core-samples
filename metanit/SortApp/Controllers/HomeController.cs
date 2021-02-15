using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SortApp.Models;

namespace SortApp.Controllers
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
        private void AddDataForTestingPurpose(UsersContext db) {
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

        public async Task<IActionResult> Index(int? company, string name, SortState sortOrder = SortState.NameAsc)
        {
            // Solution 1
            // устанавливаем ряд переменных во ViewData, которые будут хранить значения для трех столбцов.
            //ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            //ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            //ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;
            //ViewData["CurrentSort"] = sortOrder;

            // формируем sql-выражение, указываем присоединить связную таблицу (JOIN INNER)
            IQueryable<User> users = _db.Users.Include(x => x.Company);

            // Фильтрация
            if (company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            // в конструкции switch..case смотрит на значение sortOrder и добавляем к sql-выражению сортировку 
            // с помощью методов OrderBy/OrderByDescending.
            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.Name),

                SortState.AgeAsc => users.OrderBy(s => s.Age),
                SortState.AgeDesc => users.OrderByDescending(s => s.Age),

                SortState.CompanyAsc => users.OrderBy(s => s.Company.Name),
                SortState.CompanyDesc => users.OrderByDescending(s => s.Company.Name),
                _ => users.OrderBy(s => s.Name),
            };

            // выполняет это sql-выражение
            // Disabling change tracking is useful for read-only scenarios
            var dbUsers = await users.AsNoTracking().ToListAsync();

            // Фильтрация
            List<Company> companies = _db.Companies.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            companies.Insert(0, new Company { Name = "Все", Id = 0 });

            // Solution 2
            IndexViewModel viewModel = new IndexViewModel
            {
                Users = dbUsers,
                SortViewModel = new SortViewModel(sortOrder),
                Companies = new SelectList(companies, "Id", "Name"),
                Name = name
            };
            
            return View(viewModel);

            // В представлении каждый заголовок столбца будет представлять ссылку. 
            // То есть мы нажимаем на столбец, и отправляется запрос на сервер, который выполняет фильтрацию.
            // <a asp-action="Index" asp-route-sortOrder="@ViewBag.NameSort">Имя</a>
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
