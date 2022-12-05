using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class WidgetProperty
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlAttribute("translatable")]
    public string? Translatable { get; set; }

    [XmlText()]
    public string? Value { get; set; }
}
