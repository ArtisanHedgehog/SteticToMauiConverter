using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class ScrollView : UIContainer
{
    [XmlAttribute]
    public string Name { get; set; }
}
