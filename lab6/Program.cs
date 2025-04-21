using lab4.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));

var app = builder.Build();

app.MapGet("/", (IOptions<MySettings> opts) =>
{
    var cfg = opts.Value;
    return Results.Ok(new
    {
        Environment = app.Environment.EnvironmentName,
        cfg.ApplicationName,
        cfg.WelcomeMessage
    });
});

app.Run();
