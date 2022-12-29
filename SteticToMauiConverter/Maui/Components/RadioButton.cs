namespace SteticToMauiConverter.Maui.Components;

using System.Xml.Serialization;

public class RadioButton : UIComponent
{
    [XmlAttribute]
    public string? GroupName { get; set; }

    [XmlAttribute]
    public string? Content { get; set; }

    [XmlAttribute]
    public bool IsChecked { get; set; }
}
