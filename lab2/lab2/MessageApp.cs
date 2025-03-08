using lab2.Services;

namespace lab2;

public class MessageApp(IMessageService messageService)
{
    public void Run()
    {
        messageService.ShowMessage("Hello from DI Container!");
    }
}
