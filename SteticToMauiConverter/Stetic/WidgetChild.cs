using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class WidgetChild
{
    [XmlElement("placeholder")]
    public object? Placeholder { get; set; }

    [XmlElement("widget")]
    public Widget? Widget { get; set; }

    [XmlArrayItem("property", IsNullable = false)]
    public ChildProperty[]? Packing { get; set; }

    [XmlAttribute("internal-child")]
    public string? InternalChild { get; set; }
}
