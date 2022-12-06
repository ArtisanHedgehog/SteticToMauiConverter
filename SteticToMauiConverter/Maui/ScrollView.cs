using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;
public class ScrollView : UIContainer
{
    [XmlAttribute]
    public string Name { get; set; }
}
