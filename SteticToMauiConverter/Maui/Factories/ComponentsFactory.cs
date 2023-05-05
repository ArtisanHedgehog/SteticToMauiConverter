namespace SteticToMauiConverter.Maui.Factories;
using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Stetic;

public class ComponentsFactory
{
    private readonly ILogger<ComponentsFactory> _logger;

    public ComponentsFactory(
        ILogger<ComponentsFactory> logger)
    {
        _logger = logger;

    }

    public ProgressBar CreateProgressBar(Widget widget)
    {
        var progressBar = new ProgressBar();

        return progressBar;
    }

    public CheckBox CreateCheckBox(Widget widget)
    {
        var result = new CheckBox();

        if (widget.Properties is not null)
        {
            foreach (var property in widget.Properties)
            {
                switch (property.Name)
                {
                    case "CanFocus": // Unused
                    case "MemberName": // Unused property
                        break;
                    default:
                        _logger.LogWarning("{UIElement}'s property {Property} is not supported", result.GetType(), property.Name);
                        break;
                }
            }
        }


        if (widget.Signals is not null)
        {
            foreach (var signal in widget.Signals)
            {
                switch (signal.Name)
                {
                    default:
                        _logger.LogWarning("Signal {Signal} is not supported", signal.Name);
                        break;
                }
            }
        }

        return result;
    }

    public Entry CreateEntry(Widget widget)
    {
        var result = new Entry();

        if (widget.Properties is not null)
        {
            foreach (var property in widget.Properties)
            {
                switch (property.Name)
                {
                    case "CanFocus": // Unused
                    case "MemberName": // Unused property
                        break;
                    default:
                        _logger.LogWarning("{UIElement}'s property {Property} is not supported", result.GetType(), property.Name);
                        break;
                }
            }
        }


        if (widget.Signals is not null)
        {
            foreach (var signal in widget.Signals)
            {
                switch (signal.Name)
                {
                    default:
                        _logger.LogWarning("Signal {Signal} is not supported", signal.Name);
                        break;
                }
            }
        }

        return result;
    }
}
