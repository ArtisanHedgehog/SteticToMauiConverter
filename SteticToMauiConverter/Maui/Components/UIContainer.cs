using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
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
    [XmlElement(typeof(ProgressBar), ElementName = nameof(ProgressBar))]
    [XmlElement(typeof(Entry), ElementName = nameof(Entry))]
    public UIComponent[]? UIComponents { get; set; }
}
