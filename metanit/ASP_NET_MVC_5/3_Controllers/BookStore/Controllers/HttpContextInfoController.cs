using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HttpContextInfoController : Controller
    {
        // GET: HttpContextInfo
        public ActionResult Index()
        {
            // с какой страницы или сайта пользователь попал к нам
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            string userIp = HttpContext.Request.UserHostAddress;
            SetCookie("UserIP", userIp);
            SetSessionValue("UserFromSiteUrl", referrer);
            return View();
        }

        public string GetHttpContextInfo()
        {
            HttpContext.Response.Write("<h1>Hello World</h1>");

            string browser = HttpContext.Request.Browser.Browser;
            // Иногда просто браузера недостаточно, тогда можно обратиться к агенту пользователя
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = GetCookie("UserIP");
            // с какой страницы или сайта пользователь попал к нам
            string referrer = GetSessionValue("UserFromSiteUrl").ToString();

            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }

        public string GetResultByResponseInstance()
        {
            // Методы объекта HttpResponse позволяют управлять ответом. 
            // Например, метод AddHeader позволяет добавить к ответу дополнительный заголовок.
            HttpContext.Response.Charset = "iso-8859-2";

            HttpContext.Response.Write("<h1>Hello World</h1>");

            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }

        public string GetUserInfo()
        {
            bool IsAdmin = HttpContext.User.IsInRole("admin"); // определяем, принадлежит ли пользователь к администраторам
            bool IsAuth = HttpContext.User.Identity.IsAuthenticated; // аутентифицирован ли пользователь
            string login = HttpContext.User.Identity.Name; // логин авторизованного пользователя

            return "<p>IsAdmin: " + IsAdmin + "</p><p>IsAuth: " + IsAuth +
                "</p><p>login: " + login + "</p>";
        }

        private void SetCookie(string key, string value) {
            var cookie = new HttpCookie(key, value);
            HttpContext.Response.Cookies.Add(cookie);
        }

        private string GetCookie(string key)
        {
            var cookie = HttpContext.Request.Cookies.Get(key);
            if (cookie == null) return string.Empty;

            return cookie.Value;
        }

        private void SetSessionValue(string key, object value)
        {
            Session.Add(key, value);
        }

        private object GetSessionValue(string key)
        {
            var value = Session[key];
            if (value == null) return string.Empty;

            return value;
        }
    }
}