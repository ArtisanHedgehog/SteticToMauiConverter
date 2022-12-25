using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class Button : UIComponent
{
    [XmlAttribute]
    public string? Text { get; set; } = null!;

    [XmlAttribute]
    public string? Clicked { get; set; }
}
