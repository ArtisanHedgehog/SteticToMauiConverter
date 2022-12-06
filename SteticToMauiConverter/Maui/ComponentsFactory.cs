using SteticToMauiConverter.Stetic;
using System.Text.RegularExpressions;

namespace SteticToMauiConverter.Maui;
public class ComponentsFactory
{
    public UIComponent? CreateComponent(Widget widget)
    {
        return widget.Class switch
        {
            Stetic.Constants.Classes.VBox => new VerticalStackLayout
            {
                UIComponents = CreateInnerComponents(widget)
            },
            Stetic.Constants.Classes.HBox => new HorizontalStackLayout
            {
                UIComponents = CreateInnerComponents(widget)
            },
            Stetic.Constants.Classes.Widget => new ContentView
            {
                Class = widget.Id ?? string.Empty,
                UIComponents = CreateInnerComponents(widget)
            },
            Stetic.Constants.Classes.ScrolledWindow => new ScrollView
            {
                Name = widget.Id ?? string.Empty,
                UIComponents = CreateInnerComponents(widget)
            },
            Stetic.Constants.Classes.Frame => new Frame
            {
                UIComponents = CreateInnerComponents(widget)
            },
            Stetic.Constants.Classes.Button => CreateButton(widget),
            Stetic.Constants.Classes.Label => CreateLabel(widget),
            Stetic.Constants.Classes.RadioButton => CreateRadioButton(widget),
            Stetic.Constants.Classes.CheckButton => CreateCheckBox(widget),
            _ => null
        };
    }

    private CheckBox CreateCheckBox(Widget widget)
    {
        var checkBox = new CheckBox();
        return checkBox;
    }

    public Button CreateButton(Widget widget)
    {
        var button = new Button();

        var textProperty = widget.Properties?.FirstOrDefault(wc => wc.Name == "Label");

        if (textProperty is not null)
        {
            button.Text = textProperty.Value;
        }

        var typeProperty = widget.Properties?.FirstOrDefault(wc => wc.Name == "Type");

        if (typeProperty is not null)
        {
            switch (typeProperty.Value)
            {
                case "TextAndIcon":
                    Console.WriteLine("[Warning!]: Buttons with images not implemented!");
                    break;
                case "TextOnly":
                    break;
            }
        }

        if(widget.Signal?.Name == "Clicked")
        {
            button.Clicked = widget.Signal?.Handler;
        }

        return button;
    }

    public Label CreateLabel(Widget widget)
    {
        var label = new Label();

        var textProperty = widget.Properties?.FirstOrDefault(wc => wc.Name == "LabelProp");

        if (textProperty is not null)
        {
            label.Text = textProperty.Value ?? string.Empty;
        }

        return label;
    }

    public RadioButton CreateRadioButton(Widget widget)
    {
        var radioButton = new RadioButton();

        var groupNameProperty = widget.Properties?.FirstOrDefault(wc => wc.Name == "Group");

        if(groupNameProperty is not null)
        {
            radioButton.GroupName = groupNameProperty.Value;
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
                    Console.WriteLine($"[Warning!!]: Unknown UI element {innerWidget?.Class}");
                }
            }
        }

        return components.ToArray();
    }
}
