using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class Widget
{
    [XmlElement("action-group")]
    public ActionGroup? ActionGroup { get; set; }

    [XmlElement("property")]
    public WidgetProperty[]? Properties { get; set; }

    [XmlElement("signal")]
    public WidgetSignal[]? Signals { get; set; }

    [XmlElement("child")]
    public WidgetChild[]? Childs { get; set; }

    [XmlElement("node")]
    public WidgetNode? Node { get; set; }

    [XmlAttribute("class")]
    public string? Class { get; set; }

    [XmlAttribute("id")]
    public string? Id { get; set; }

    [XmlAttribute("design-size")]
    public string? DesignSize { get; set; }
}