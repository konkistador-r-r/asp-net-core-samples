using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIdentityApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentityApp.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _context;
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await PrepareByConextIndexViewData();
            return View(users);
        }
        public async Task<IActionResult> ByManager()
        {
            var users = await PrepareByManagerIndexViewData();
            return View("Index", users);
        }

        public async Task<IActionResult> AddRoleByContext()
        {
            var newRole = new IdentityRole { Name = "simpleUser", NormalizedName = "SIMPLEUSER" };
            _context.Add(newRole);
            await _context.SaveChangesAsync();

            var users = await PrepareByConextIndexViewData();
            return View("Index", users);
        }

        public async Task<IActionResult> AddRoleByManager()
        {
            var newRole = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
            await _roleManager.CreateAsync(newRole);

            var users = await PrepareByManagerIndexViewData();
            return View("Index", users);
        }

        private async Task<IEnumerable<IdentityUser>> PrepareByConextIndexViewData() {
            var users = await _context.Users.ToListAsync();
            var roles = await _context.Roles.ToListAsync();
            ViewData["Roles"] = roles;

            return users;
        }

        private async Task<IEnumerable<IdentityUser>> PrepareByManagerIndexViewData()
        {
            var users = await _userManager.Users.ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();
            ViewData["Roles"] = roles;

            return users;
        }
    }
}