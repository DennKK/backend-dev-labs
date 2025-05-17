using Microsoft.AspNetCore.Mvc;

namespace lab8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["SessionName"] = HttpContext.Session.GetString("Username") ?? "не задано";
            ViewData["City"] = Request.Cookies["City"] ?? "не задан";

            return View();
        }

        [HttpPost]
        public IActionResult SetSession(string username)
        {
            HttpContext.Session.SetString("Username", username);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearSession()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetCookie(string city)
        {
            Response.Cookies.Append("City", city, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(10)
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCookie()
        {
            Response.Cookies.Delete("City");
            return RedirectToAction("Index");
        }
    }
}
