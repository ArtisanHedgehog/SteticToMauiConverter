using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;
public class VerticalStackLayout : UIComponent
{
    [XmlElement(typeof(VerticalStackLayout), ElementName = nameof(VerticalStackLayout))]
    [XmlElement(typeof(HorizontalStackLayout), ElementName = nameof(HorizontalStackLayout))]
    public UIComponent[]? UIComponents { get; set; }
}
