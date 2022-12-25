using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Stetic;

namespace SteticToMauiConverter.Maui.Factories;

public class LabelsFactory
{
    private readonly ILogger<LabelsFactory> _logger;

    public LabelsFactory(ILogger<LabelsFactory> logger)
    {
        _logger = logger;
    }

    public Label CreateLabel(Widget widget)
    {
        var label = new Label();

        if (widget.Properties is null)
        {
            return label;
        }

        foreach (var property in widget.Properties)
        {
            switch (property.Name)
            {
                case "LabelProp":
                    label.Text = property.Value ?? string.Empty;
                    break;
                case "Xalign":
                    switch(property.Value)
                    {
                        case "0":
                            label.HorizontalOptions = "Start";
                            break;
                        case "0,5":
                            label.HorizontalOptions = "Center";
                            break;
                        case "1":
                            label.HorizontalOptions = "End";
                            break;
                        default:
                            _logger.LogWarning("Unsupported Xalign value: {Value}", property.Value);
                            break;
                    }
                    break;
                case "MemberName": // Unused property
                    break;
                default:
                    _logger.LogWarning("Property {Property} is not supported", property.Name);
                    break;
            }
        }

        if (widget.Signals is null)
        {
            return label;
        }

        foreach (var signal in widget.Signals)
        {
            switch (signal.Name)
            {
                default:
                    _logger.LogWarning("Signal {Signal} is not supported", signal.Name);
                    break;
            }
        }

        return label;
    }
}
