using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class Property
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlText()]
    public string? Value { get; set; }
}
