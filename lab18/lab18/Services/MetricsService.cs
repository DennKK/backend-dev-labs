using Prometheus;

namespace lab18.Services;

public class MetricsService
{
    private readonly Counter _totalRequests =
        Metrics.CreateCounter("app_requests_total", "Total number of requests received");

    private readonly Counter _errorCount = Metrics.CreateCounter("app_errors_total", "Total number of errors");

    private readonly Histogram _requestDuration = Metrics.CreateHistogram("app_request_duration_seconds",
        "Request duration in seconds",
        new HistogramConfiguration
        {
            Buckets = Histogram.ExponentialBuckets(0.01, 2, 10)
        });

    private readonly Gauge _activeConnections =
        Metrics.CreateGauge("app_active_connections", "Number of active connections");

    public void RequestReceived()
    {
        _totalRequests.Inc();
    }

    public void ErrorOccurred()
    {
        _errorCount.Inc();
    }

    public IDisposable MeasureRequestDuration()
    {
        return _requestDuration.NewTimer();
    }

    public void ConnectionOpened()
    {
        _activeConnections.Inc();
    }

    public void ConnectionClosed()
    {
        _activeConnections.Dec();
    }
}
