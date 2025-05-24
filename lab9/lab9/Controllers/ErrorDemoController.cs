using lab9.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace lab9.Controllers;

[Route("[controller]")]
public class ErrorDemoController : Controller
{
    [HttpGet("404")]
    public new IActionResult NotFound()
    {
        throw new ResourceNotFoundException("Запрашиваемый ресурс не найден");
    }

    [HttpGet("400")]
    public new IActionResult BadRequest()
    {
        throw new ValidationException("Ошибка валидации данных");
    }

    [HttpGet("500")]
    public IActionResult DatabaseError()
    {
        throw new DatabaseOperationException("Ошибка при работе с базой данных");
    }

    [HttpGet("nested")]
    public IActionResult NestedError()
    {
        try
        {
            throw new InvalidOperationException("Первичная внутренняя ошибка");
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseOperationException("Ошибка с вложенным исключением", ex);
        }
    }

    [HttpGet("ok")]
    public IActionResult Success()
    {
        return Ok(new
        {
            status = "success",
            message = "Операция выполнена успешно",
            timestamp = DateTime.Now
        });
    }
}
