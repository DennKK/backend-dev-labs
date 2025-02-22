using lab3.Interfaces;

namespace lab3;

public class App(IMyService myService)
{
    public void Run()
    {
        Console.WriteLine("Starting...");
        myService.DoWork();
    }
}
