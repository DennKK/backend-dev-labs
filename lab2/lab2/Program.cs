using lab2.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab2;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var service = host.Services.GetRequiredService<MessageApp>();
        service.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddTransient<IMessageService, MessageService>();
                services.AddTransient<MessageApp>();
            });
}
