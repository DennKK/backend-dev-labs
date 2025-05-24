namespace lab9.Models;

public class ErrorViewModel
{
    public required string RequestId { get; init; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public int StatusCode { get; init; }

    public string? Message { get; init; }
}
