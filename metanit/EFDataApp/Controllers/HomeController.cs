using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFDataApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        #region Создание и вывод
        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                //  формируется sql-выражение INSERT
                db.Users.Add(user);
                // выполняет это выражение, тем самым добавляя данные в базу данных
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        #endregion

        #region Редактирование
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        #endregion

        #region Удаление
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            // удаляемый объект просто извлекается из БД и передается в представление.
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            // получаем удаляемый объект и удаляем его
            if (id != null)
            {
                // можем произвести небольшую оптимизацию
                // Иногда бывает важно узнать перед удалением, а есть ли такой объект в БД.
                // Однако в данном случае мы получаем два запроса к бд - один на получение объекта и второй на его удаление.
                //User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                //if (user != null)
                //{
                //    db.Users.Remove(user);
                //    await db.SaveChangesAsync();
                //    return RedirectToAction("Index");
                //}

                // И мы можем оптимизировать метод следующим образом:
                User user = new User { Id = id.Value };
                db.Entry(user).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        #endregion

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
