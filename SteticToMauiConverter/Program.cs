using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SteticToMauiConverter;
using SteticToMauiConverter.Configuration;
using SteticToMauiConverter.Maui;
using SteticToMauiConverter.Maui.Factories;
using SteticToMauiConverter.Stetic;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json");
    })
    .ConfigureServices((hostingContext, services) =>
    {
        services.AddSingleton<Application>();
        services.AddSingleton<SteticReader>();
        services.AddSingleton<MauiXamlGenerator>();
        services.AddSingleton<ButtonsFactory>();
        services.AddSingleton<LabelsFactory>();
        services.AddSingleton<ComponentsFactory>();

        services.Configure<ApplicationOptions>(
            hostingContext.Configuration.GetSection(nameof(ApplicationOptions)));
    })
    .ConfigureLogging((hostContext, logging) =>
    {
        logging.AddConsole();
    }).Build();

var logger = host.Services.GetService<ILogger<Program>>()
    ?? throw new InvalidOperationException("Can't get logger");

try
{
    var app = host.Services.GetService<Application>()
    ?? throw new InvalidOperationException(
    $"Configuration missing for {nameof(Application)} service");

    app.Run();
}
catch (Exception ex)
{
    logger.LogCritical(ex.Message);
}
