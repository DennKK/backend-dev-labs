using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;

[Route("products")]
public class ProductController : Controller
{
    [Route("")]
    public IActionResult List()
    {
        return Content("Список всех продуктов");
    }

    [Route("{id:int:min(1)}")]
    public IActionResult Details(int id)
    {
        return Content($"Детали продукта с ID: {id}");
    }

    [Route("category/{categoryName:maxlength(50)}")] 
    public IActionResult Category(string categoryName)
    {
        return Content($"Продукты в категории: {categoryName}");
    }

    [Route("search/{query?}")]
    public IActionResult Search(string query = "all")
    {
        return Content($"Поиск продуктов по запросу: {query}");
    }
}
