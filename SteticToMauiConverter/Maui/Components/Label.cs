using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class Label : UIComponent
{
    [XmlAttribute]
    public string Text { get; set; } = null!;
}
