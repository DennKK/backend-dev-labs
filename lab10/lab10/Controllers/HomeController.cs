using lab10.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab10.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetJsonData()
    {
        var person = new Person
        {
            Id = 1,
            Name = "Иван",
            Age = 30
        };

        return Json(person);
    }

    public IActionResult DownloadFile()
    {
        const string filePath = "files/sample.txt";
        const string mimeType = "text/plain";
        const string fileName = "sample.txt";

        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath), mimeType, fileName);
    }
}
