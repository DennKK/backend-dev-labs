namespace lab9.Models.Exceptions;

public class ResourceNotFoundException(string message) : Exception(message);

public class DatabaseOperationException : Exception
{
    public DatabaseOperationException(string message) : base(message)
    {
    }

    public DatabaseOperationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

public class ValidationException(string message) : Exception(message);
