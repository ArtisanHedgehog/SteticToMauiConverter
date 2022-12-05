using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class IconsSet
{
    [XmlElement("source")]
    public Source? Source { get; set; }

    [XmlAttribute("id")]
    public string? Id { get; set; }
}
