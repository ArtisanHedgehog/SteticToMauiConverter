using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SteticToMauiConverter;
using SteticToMauiConverter.Configuration;
using SteticToMauiConverter.Maui;
using SteticToMauiConverter.Maui.Factories;
using SteticToMauiConverter.Stetic;

var hostBuilder = new HostBuilder()
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
        services.AddSingleton<ComponentsFactory>();

        services.Configure<ApplicationOptions>(
            hostingContext.Configuration.GetSection(nameof(ApplicationOptions)));
    })
    .ConfigureLogging((hostContext, logging) =>
    {
        logging.AddConsole();
    });

var host = hostBuilder.Build();

var app = host.Services.GetService<Application>()
    ?? throw new InvalidOperationException(
        $"Configuration missing for {nameof(Application)} service");

app.Run();
