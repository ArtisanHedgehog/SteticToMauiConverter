namespace SteticToMauiConverter.Maui.Factories;

using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Stetic;

public class ComponentsFactory
{
    private readonly ILogger<ComponentsFactory> _logger;
    private readonly ButtonsFactory _buttonsFactory;
    private readonly LabelsFactory _labelsFactory;

    public ComponentsFactory(
        ILogger<ComponentsFactory> logger,
        ButtonsFactory buttonsFactory,
        LabelsFactory labelsFactory)
    {
        _logger = logger;
        _buttonsFactory = buttonsFactory;
        _labelsFactory = labelsFactory;
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
            Constants.Classes.Label => _labelsFactory.CreateLabel(widget),
            Constants.Classes.RadioButton => _buttonsFactory.CreateRadioButton(widget),
            Constants.Classes.CheckButton => CreateCheckBox(widget),
            Constants.Classes.ProgressBar => CreateProgressBar(widget),
            Constants.ExternalWidgets.Label => _labelsFactory.CreateLabel(widget),
            Constants.ExternalWidgets.CheckButton => CreateCheckBox(widget),
            Constants.ExternalWidgets.ProgressBar => CreateProgressBar(widget),
            _ => null
        };
    }

    private ProgressBar CreateProgressBar(Widget widget)
    {
        var progressBar = new ProgressBar();

        return progressBar;
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
