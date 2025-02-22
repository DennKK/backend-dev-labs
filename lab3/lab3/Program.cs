using lab3.Interfaces;
using lab3.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab3;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();

        var app = host.Services.GetRequiredService<App>();
        app.Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<App>();
                services.AddTransient<IMyService, MyService>();
            });
}
