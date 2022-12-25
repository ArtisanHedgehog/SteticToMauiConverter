using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class Button : UIComponent
{
    [XmlAttribute]
    public string? Text { get; set; } = null!;

    [XmlAttribute]
    public string? Clicked { get; set; }

    [XmlAttribute("ToolTipProperties.Text")] //Maybe later need to be expanded to full class
    public string? Tooltip { get; set; } = null!;
}
