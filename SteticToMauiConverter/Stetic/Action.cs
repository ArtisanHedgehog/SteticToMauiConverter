using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class Action
{
    [XmlElement("property")]
    public ActionProperty[]? Properties { get; set; }

    [XmlElement("signal")]
    public ActionSignal? Signal { get; set; }

    [XmlAttribute("id")]
    public string? Id { get; set; }
}