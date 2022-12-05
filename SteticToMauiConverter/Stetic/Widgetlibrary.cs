using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class WidgetLibrary
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlAttribute("internal")]
    public bool Internal { get; set; } = false;
}
