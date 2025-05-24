using System.Net;
using System.Text.Json;
using lab9.Models.Exceptions;

namespace lab9.Models.Middleware;

public class ErrorHandlingMiddleware(
    RequestDelegate next,
    ILogger<ErrorHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception, "Произошла ошибка: {Message}", exception.Message);

        var response = context.Response;
        response.ContentType = "application/json";

        var (statusCode, message) = GetExceptionDetails(exception);
        response.StatusCode = (int)statusCode;

        var result = new
        {
            StatusCode = (int)statusCode,
            Message = message,
            RequestId = context.TraceIdentifier,
            Timestamp = DateTime.UtcNow
        };

        await response.WriteAsync(JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            WriteIndented = true
        }));
    }

    private (HttpStatusCode statusCode, string message) GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            ResourceNotFoundException ex => (HttpStatusCode.NotFound, ex.Message),
            ValidationException ex => (HttpStatusCode.BadRequest, ex.Message),
            DatabaseOperationException ex => (HttpStatusCode.InternalServerError, ex.Message),
            _ => (HttpStatusCode.InternalServerError, "Произошла внутренняя ошибка сервера")
        };
    }
}
