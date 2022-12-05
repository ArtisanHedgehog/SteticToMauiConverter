using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class Configuration
{
    [XmlElement("images-root-path")]
    public string? ImagesRootPath { get; set; }

    [XmlElement("target-gtk-version")]
    public decimal Targetgtkversion { get; set; }
}
