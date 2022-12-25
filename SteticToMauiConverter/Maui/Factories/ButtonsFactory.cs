namespace SteticToMauiConverter.Maui.Factories;

using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Stetic;

public class ButtonsFactory
{
    private readonly ILogger<ButtonsFactory> _logger;

    public ButtonsFactory(ILogger<ButtonsFactory> logger)
    {
        _logger = logger;
    }

    public Button CreateButton(Widget widget)
    {
        var button = new Button();

        if (widget.Properties is null)
        {
            return button;
        }

        foreach (var property in widget.Properties)
        {
            switch (property.Name)
            {
                case "Label":
                    button.Text = property.Value;
                    break;
                case "Type":
                    if (property.Value == "TextAndIcon")
                    {
                        _logger.LogWarning("Buttons with images not implemented!");
                    }
                    else if (property.Value == "TextOnly") { }
                    else
                    {
                        _logger.LogWarning("Type {Type} is not supported", property.Value);
                    }
                    break;
                default:
                    _logger.LogWarning("Property {Property} is not supported", property.Name);
                    break;
            }
        }

        if (widget.Signals is null)
        {
            return button;
        }

        foreach (var signal in widget.Signals)
        {
            switch (signal.Name)
            {
                case "Clicked":
                    button.Clicked = signal.Handler;
                    break;
                default:
                    _logger.LogWarning("Signal {Signal} is not supported", signal.Name);
                    break;
            }
        }

        return button;
    }
}
