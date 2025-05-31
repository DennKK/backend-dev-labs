using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab15.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult PublicEndpoint()
    {
        return Ok("This is a public endpoint that anyone can access.");
    }

    [HttpGet("user")]
    [Authorize]
    public IActionResult UserEndpoint()
    {
        return Ok("This endpoint requires authentication.");
    }

    [HttpGet("manager")]
    [Authorize(Roles = "Manager,Admin")]
    public IActionResult ManagerEndpoint()
    {
        return Ok("This endpoint is only accessible by Managers and Admins.");
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminEndpoint()
    {
        return Ok("This endpoint is only accessible by Admins.");
    }
}
