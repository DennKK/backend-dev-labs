using lab3.Interfaces;

namespace lab3.Services;

public class MyService : IMyService
{
    public void DoWork()
    {
        Console.WriteLine("MyService is doing work...");
    }
}
