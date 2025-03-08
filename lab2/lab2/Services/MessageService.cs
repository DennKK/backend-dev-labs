namespace lab2.Services;

public class MessageService : IMessageService
{
    public void ShowMessage(string message)
    {
        Console.WriteLine($"Message: {message}");
    }
}
