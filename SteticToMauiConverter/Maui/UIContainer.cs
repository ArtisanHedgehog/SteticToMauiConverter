using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;
public class UIContainer : UIComponent
{
    [XmlElement(typeof(VerticalStackLayout), ElementName = nameof(VerticalStackLayout))]
    [XmlElement(typeof(HorizontalStackLayout), ElementName = nameof(HorizontalStackLayout))]
    [XmlElement(typeof(ScrollView), ElementName = nameof(ScrollView))]
    [XmlElement(typeof(Frame), ElementName = nameof(Frame))]
    [XmlElement(typeof(Label), ElementName = nameof(Label))]
    [XmlElement(typeof(Button), ElementName = nameof(Button))]
    [XmlElement(typeof(RadioButton), ElementName = nameof(RadioButton))]
    [XmlElement(typeof(CheckBox), ElementName = nameof(CheckBox))]
    public UIComponent[]? UIComponents { get; set; }
}
