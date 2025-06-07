using lab18.Services;

namespace lab18.Middleware;

public class MetricsMiddleware(RequestDelegate next, MetricsService metricsService)
{
    public async Task InvokeAsync(HttpContext context)
    {
        metricsService.RequestReceived();
        metricsService.ConnectionOpened();

        using (metricsService.MeasureRequestDuration())
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {
                metricsService.ErrorOccurred();
                throw;
            }
            finally
            {
                metricsService.ConnectionClosed();
            }
        }
    }
}
