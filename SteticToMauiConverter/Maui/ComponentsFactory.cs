using SteticToMauiConverter.Stetic;
using System.ComponentModel;

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
                Class = widget.Id,
                UIComponents = CreateInnerComponents(widget)
            },
            _ => null
        };
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
