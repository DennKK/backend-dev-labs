using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Content("Добро пожаловать на главную страницу!");
    }

    [Route("about")] 
    public IActionResult About()
    {
        return Content("Страница О нас");
    }
}
