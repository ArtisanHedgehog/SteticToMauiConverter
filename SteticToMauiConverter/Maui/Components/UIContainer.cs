using SteticToMauiConverter.Maui.Components.Shells;
using SteticToMauiConverter.Maui.Components.Tables;
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
    [XmlElement(typeof(TableView), ElementName = nameof(TableView))]
    [XmlElement(typeof(Shell), ElementName = nameof(Shell))]
    public UIComponent[]? UIComponents { get; set; }
}
