namespace SteticToMauiConverter.Maui.Factories;

using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Stetic;

public class ComponentsFactory
{
    private readonly ILogger<ComponentsFactory> _logger;
    private readonly ButtonsFactory _buttonsFactory;

    public ComponentsFactory(
        ILogger<ComponentsFactory> logger,
        ButtonsFactory buttonsFactory)
    {
        _logger = logger;
        _buttonsFactory = buttonsFactory;
    }

    public UIComponent? CreateComponent(Widget widget)
    {
        return widget.Class switch
        {
            Constants.Classes.VBox => new VerticalStackLayout
            {
                UIComponents = CreateInnerComponents(widget)
            },
            Constants.Classes.HBox => new HorizontalStackLayout
            {
                UIComponents = CreateInnerComponents(widget)
            },
            Constants.Classes.Widget => new ContentView
            {
                Class = widget.Id ?? string.Empty,
                UIComponents = CreateInnerComponents(widget)
            },
            Constants.Classes.ScrolledWindow => new ScrollView
            {
                Name = widget.Id ?? string.Empty,
                UIComponents = CreateInnerComponents(widget)
            },
            Constants.Classes.Frame => new Frame
            {
                UIComponents = CreateInnerComponents(widget)
            },
            Constants.Classes.Button => _buttonsFactory.CreateButton(widget),
            Constants.Classes.Label => CreateLabel(widget),
            Constants.Classes.RadioButton => CreateRadioButton(widget),
            Constants.Classes.CheckButton => CreateCheckBox(widget),
            _ => null
        };
    }

    private CheckBox CreateCheckBox(Widget widget)
    {
        var checkBox = new CheckBox();

        if (widget.Properties is null)
        {
            return checkBox;
        }

        foreach (var property in widget.Properties)
        {
            switch (property.Name)
            {
                default:
                    _logger.LogWarning("Property {Property} is not supported", property.Name);
                    break;
            }
        }

        if (widget.Signals is null)
        {
            return checkBox;
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

        return checkBox;
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

    public RadioButton CreateRadioButton(Widget widget)
    {
        var radioButton = new RadioButton();

        if (widget.Properties is null)
        {
            return radioButton;
        }

        foreach (var property in widget.Properties)
        {
            switch (property.Name)
            {
                case "Group":
                    radioButton.GroupName = property.Value;
                    break;
                default:
                    _logger.LogWarning("Property {Property} is not supported", property.Name);
                    break;
            }
        }

        if (widget.Signals is null)
        {
            return radioButton;
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

        return radioButton;
    }

    public UIComponent[] CreateInnerComponents(Widget Widget)
    {
        List<UIComponent> components = new();

        if (Widget.Childs is null)
        {
            return Array.Empty<UIComponent>();
        }

        foreach (var innerWidget in Widget.Childs.Select(wc => wc.Widget))
        {
            if (innerWidget is not null)
            {
                var newComponent = CreateComponent(innerWidget);

                if (newComponent is not null)
                {
                    components.Add(newComponent);
                }
                else
                {
                    _logger.LogWarning("Unknown UI element {Class}", innerWidget?.Class);
                }
            }
        }

        return components.ToArray();
    }
}
