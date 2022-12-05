using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class ActionGroup
{
    [XmlElement("action")]
    public Action[]? Action { get; set; }

    [XmlAttribute("name")]
    public string? Name { get; set; }
}
