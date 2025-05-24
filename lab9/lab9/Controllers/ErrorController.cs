using lab9.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace lab9.Controllers;

[Route("Error")]
public class ErrorController : Controller
{
    [Route("{statusCode:int}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        var errorViewModel = new ErrorViewModel
        {
            RequestId = HttpContext.TraceIdentifier,
            StatusCode = statusCode,
            Message = statusCode switch
            {
                404 => "Requested resource not found",
                400 => "Bad request",
                500 => "Internal server error",
                _ => "An error occurred"
            }
        };

        return View("~/Views/Shared/Error/Error.cshtml", errorViewModel);
    }

    [Route("")]
    public IActionResult Error()
    {
        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var errorViewModel = new ErrorViewModel
        {
            RequestId = HttpContext.TraceIdentifier,
            StatusCode = 500,
            Message = exceptionHandlerPathFeature?.Error.Message ?? "An unexpected error occurred"
        };

        return View("~/Views/Shared/Error/Error.cshtml", errorViewModel);
    }
}
