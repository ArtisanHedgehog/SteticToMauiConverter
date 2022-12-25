using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class RadioButton : UIComponent
{
    [XmlAttribute]
    public string? GroupName { get; set; }

    [XmlAttribute]
    public string? Content { get; set; }

    [XmlAttribute]
    public bool IsChecked { get; set; }
}
