using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieAuthApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }

        public IActionResult GetSomething()
        {
            if (User.Identity.IsAuthenticated)
            {
                var nameClaimByPrincipal = User.FindFirst(System.Security.Claims.ClaimsIdentity.DefaultNameClaimType);
                var nameClaimByIdentity = (User.Identity as System.Security.Claims.ClaimsIdentity).FindAll(System.Security.Claims.ClaimsIdentity.DefaultNameClaimType).FirstOrDefault();
                return Content(User.Identity.Name + " = " 
                    + nameClaimByPrincipal.Value
                    + " = " + nameClaimByIdentity.Value);
            }
            return Content("Не аутентифицирован");
        }

        [AllowAnonymous]
        public IActionResult GetFreeInfo()
        {
            return Content("Allowed for Anonymous guests");
        }
    }
}