using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using SteticToMauiConverter.Configuration;
using SteticToMauiConverter.Maui;
using SteticToMauiConverter.Stetic;
using System.Text;

namespace SteticToMauiConverter;

public class Application
{
    private readonly IOptions<ApplicationOptions> _options;
    private readonly ILogger<Application> _logger;
    private readonly SteticReader _steticReader;
    private readonly MauiXamlGenerator _mauiXamlGenerator;

    public Application(
        IOptions<ApplicationOptions> options,
        ILogger<Application> logger,
        SteticReader steticReader,
        MauiXamlGenerator mauiXamlGenerator)
    {
        _options = options;
        _logger = logger;
        _steticReader = steticReader;
        _mauiXamlGenerator = mauiXamlGenerator;
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
    }
}
