using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;
public class Label : UIComponent
{
    [XmlAttribute]
    public string Text { get; set; } = null!;
}
