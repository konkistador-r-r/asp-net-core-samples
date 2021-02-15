using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAndRole.Models;

namespace UserAndRole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            ViewBag.Content = $"ваша роль: {role}";
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult About()
        {
            return Content("Вход только для администратора");
        }

        public IActionResult GetSomething()
        {
            if (User.IsInRole("admin"))
            {
                return Content("Вход только для администратора");
            }
            return Content("Не аутентифицирован");
        }

        [Authorize(Policy = "OnlyForLondon")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Policy = "OnlyForMicrosoft")]
        public IActionResult OnlyForMicrosoft()
        {
            return Content("Only for Microsoft employees");
        }

        [Authorize(Policy = "AgeLimit")]
        public IActionResult AgeLimit()
        {
            return Content(">= 18");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
