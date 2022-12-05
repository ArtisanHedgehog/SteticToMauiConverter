using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;

[XmlRoot(Namespace = Constants.Maui2021)]
public class ContentView
{
    [XmlAttribute("Class", Namespace = Constants.Maui2009)]
    public string Class { get; set; } = null!;
}
