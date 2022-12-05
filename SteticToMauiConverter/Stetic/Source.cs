using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class Source
{
    [XmlElement("property")]
    public Property? Property { get; set; }
}
