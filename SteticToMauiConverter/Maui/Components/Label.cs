using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class Label : UIComponent
{
    [XmlAttribute]
    public string Text { get; set; } = null!;

    [XmlAttribute]
    public string HorizontalOptions { get; set; } = null!;

    [XmlAttribute]
    public string TextType { get; set; } = null!;
}
