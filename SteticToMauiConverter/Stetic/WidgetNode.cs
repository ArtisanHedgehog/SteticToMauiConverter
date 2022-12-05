using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class WidgetNode
{
    [XmlElement("node")]
    public WidgetNode[]? Node { get; set; }

    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlAttribute("type")]
    public string? Type { get; set; }

    [XmlAttribute("action")]
    public string? Action { get; set; }
}
