namespace SteticToMauiConverter.Maui.Factories;
using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Maui.Components.Shells;
using SteticToMauiConverter.Maui.Components.Tables;
using SteticToMauiConverter.Stetic;

public class ContainersFactory
{
    private readonly ILogger<ContainersFactory> _logger;
    private readonly ButtonsFactory _buttonsFactory;
    private readonly LabelsFactory _labelsFactory;
    private readonly ComponentsFactory _componentsFactory;
    private readonly TableFactory _tableFactory;
    private readonly ShellFactory _shellFactory;

    private readonly Dictionary<string, int> _unknownElements = new();

    public Dictionary<string, int> UnknownElements => _unknownElements;

    public ContainersFactory(
        ILogger<ContainersFactory> logger,
        ButtonsFactory buttonsFactory,
        LabelsFactory labelsFactory,
        ComponentsFactory componentsFactory,
        TableFactory tableFactory,
        ShellFactory shellFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _buttonsFactory = buttonsFactory ?? throw new ArgumentNullException(nameof(buttonsFactory));
        _labelsFactory = labelsFactory ?? throw new ArgumentNullException(nameof(labelsFactory));
        _componentsFactory = componentsFactory ?? throw new ArgumentNullException(nameof(componentsFactory));
        _tableFactory = tableFactory ?? throw new ArgumentNullException(nameof(tableFactory));
        _shellFactory = shellFactory ?? throw new ArgumentNullException(nameof(shellFactory));
    }

    public VerticalStackLayout CreateVerticalStackLayout(Widget widget)
    {
        return new VerticalStackLayout
        {
            UIComponents = CreateInnerComponents(widget),
        };
    }

    public HorizontalStackLayout CreateHorizontalStackLayout(Widget widget)
    {
        return new HorizontalStackLayout
        {
            UIComponents = CreateInnerComponents(widget),
        };
    }

    public ContentView CreateContentView(Widget widget)
    {
        return new ContentView
        {
            Class = widget.Id ?? string.Empty,
            UIComponents = CreateInnerComponents(widget)
        };
    }

    public ScrollView CreateScrollView(Widget widget)
    {
        return new ScrollView
        {
            Name = widget.Id ?? string.Empty,
            UIComponents = CreateInnerComponents(widget)
        };
    }

    public Frame CreateFrame(Widget widget)
    {
        return new Frame
        {
            UIComponents = CreateInnerComponents(widget)
        };
    }

    private UIComponent[] CreateInnerComponents(Widget Widget)
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

                    if(innerWidget?.Class is not null)
                    {
                        if (_unknownElements.TryGetValue(innerWidget.Class, out int _))
                        {
                            _unknownElements[innerWidget.Class]++;
                        }
                        else
                        {
                            _unknownElements.Add(innerWidget.Class, 1);
                        }
                    }
                }
            }
        }

        return components.ToArray();
    }

    public UIComponent? CreateComponent(Widget widget)
    {
        return widget.Class switch
        {
            Constants.Classes.VBox => CreateVerticalStackLayout(widget),
            Constants.ExternalWidgets.VBox => CreateVerticalStackLayout(widget),
            Constants.Classes.HBox => CreateHorizontalStackLayout(widget),
            Constants.ExternalWidgets.HBox => CreateHorizontalStackLayout(widget),
            Constants.Classes.Widget => CreateContentView(widget),
            Constants.Classes.ScrolledWindow => CreateScrollView(widget),
            Constants.Classes.Frame => CreateFrame(widget),
            Constants.Classes.Button => widget.Properties?.Contains(
                    new WidgetProperty { Name = "Type" , Value = "TextAndIcon" }) ?? false
                ? _buttonsFactory.CreateImageButton(widget)
                : _buttonsFactory.CreateButton(widget),
            Constants.ExternalWidgets.Button => widget.Properties?.Contains(
                    new WidgetProperty { Name = "Type", Value = "TextAndIcon" }) ?? false
                ? _buttonsFactory.CreateImageButton(widget)
                : _buttonsFactory.CreateButton(widget),
            Constants.Classes.Label => _labelsFactory.CreateLabel(widget),
            Constants.ExternalWidgets.Label => _labelsFactory.CreateLabel(widget),
            Constants.Classes.RadioButton => _buttonsFactory.CreateRadioButton(widget),
            Constants.ExternalWidgets.RadioButton => _buttonsFactory.CreateRadioButton(widget),
            Constants.Classes.CheckButton => _componentsFactory.CreateCheckBox(widget),
            Constants.ExternalWidgets.CheckButton => _componentsFactory.CreateCheckBox(widget),
            Constants.Classes.ProgressBar => _componentsFactory.CreateProgressBar(widget),
            Constants.ExternalWidgets.ProgressBar => _componentsFactory.CreateProgressBar(widget),
            Constants.Classes.Table => _tableFactory.CreateTable(widget),
            Constants.Classes.Notebook => _shellFactory.CreateShell(widget),
            Constants.ExternalWidgets.Notebook => _shellFactory.CreateShell(widget),
            Constants.Classes.Entry => _componentsFactory.CreateEntry(widget),
            _ => null
        };
    }
}
