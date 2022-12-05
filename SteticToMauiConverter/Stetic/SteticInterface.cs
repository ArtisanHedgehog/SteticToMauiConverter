using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
[XmlRoot("stetic-interface", Namespace = "", IsNullable = false)]
public partial class SteticInterface
{
    [XmlElement("configuration")]
    public Configuration? Configuration { get; set; }

    [XmlArrayItem("widget-library", IsNullable = false)]
    public WidgetLibrary[]? Import { get; set; }

    [XmlArray("icon-factory")]
    [XmlArrayItem("icon-set", IsNullable = false)]
    public IconsSet[]? Iconfactory { get; set; }

    [XmlElement("widget")]
    public Widget[]? Widgets { get; set; }

    public IEnumerable<Widget> GetComponentWidgets()
    {
        return Widgets?.Where(w => w.Class == Constants.Classes.Widget)
                ?? throw new InvalidOperationException("There is no widgets!!");
    }
}