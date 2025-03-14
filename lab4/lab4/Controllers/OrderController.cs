using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers;

[Route("orders")] 
public class OrderController : Controller
{
    [Route("checkout")] 
    public IActionResult Checkout()
    {
        return Content("Оформление заказа");
    }
}
