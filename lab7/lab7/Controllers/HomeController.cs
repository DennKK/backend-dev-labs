using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController(ILogger<HomeController> logger) : ControllerBase
    {
        [HttpGet("info")]
        public IActionResult Info()
        {
            logger.LogInformation("Requested {Endpoint} with parameter {Param}", nameof(Info), Request.QueryString);
            return Ok(new { Message = "This is an informational message." });
        }

        [HttpGet("debug")]
        public IActionResult Debug()
        {
            logger.LogDebug("Executing Debug method in {Endpoint}", nameof(Debug));
            return Ok(new { Message = "This is a debug message." });
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            logger.LogError("Error method called; an exception will be thrown.");
            throw new InvalidOperationException("Example exception for error logging.");
        }
    }
}
