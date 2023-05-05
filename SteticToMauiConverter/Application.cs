namespace SteticToMauiConverter;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SteticToMauiConverter.Configuration;
using SteticToMauiConverter.Maui;
using SteticToMauiConverter.Maui.Factories;
using SteticToMauiConverter.Stetic;
using System.Text;

public class Application
{
    private readonly IOptions<ApplicationOptions> _options;
    private readonly ILogger<Application> _logger;
    private readonly SteticReader _steticReader;
    private readonly MauiXamlGenerator _mauiXamlGenerator;
    private readonly ContainersFactory _containersFactory;

    public Application(
        IOptions<ApplicationOptions> options,
        ILogger<Application> logger,
        SteticReader steticReader,
        MauiXamlGenerator mauiXamlGenerator,
        ComponentsFactory componentsFactory,
        ContainersFactory containersFactory)
    {
        _options = options;
        _logger = logger;
        _steticReader = steticReader;
        _mauiXamlGenerator = mauiXamlGenerator;
        _containersFactory = containersFactory;
    }

    public void Run()
    {
        var source = _steticReader.Read(_options.Value.InputFilePath);

        var componentsToGenerate = source.GetComponentWidgets();

        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("This components will be generated:");

        foreach (var widgetClass in componentsToGenerate.Select(w => w.Id))
        {
            stringBuilder.AppendLine(widgetClass);
        }

        var componentsWillBeGenerated = stringBuilder.ToString();

        _logger.LogInformation(componentsWillBeGenerated);

        foreach (var component in componentsToGenerate)
        {
            _mauiXamlGenerator.Generate(component);
        }

        _logger.LogInformation("Done!");

        if (_containersFactory.UnknownElements.Any())
        {
            _logger.LogWarning("Total unknown elements:\n{list}",
                string.Join("\n", _containersFactory.UnknownElements.Select((pair) => $"{pair.Key} : {pair.Value}")));
        }
    }
}
