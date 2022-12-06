using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;
public class RadioButton : UIComponent
{
    [XmlAttribute]
    public string? GroupName { get; set; }
}
