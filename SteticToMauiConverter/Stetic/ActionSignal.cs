using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class ActionSignal
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlAttribute("handler")]
    public string? Handler { get; set; }
}
