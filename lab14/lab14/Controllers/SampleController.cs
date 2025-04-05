using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace lab14.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("AllowAll")]
public class SampleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("CORS работает!");
}
