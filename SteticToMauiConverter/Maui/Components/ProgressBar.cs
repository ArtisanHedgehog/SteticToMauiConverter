using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class ProgressBar : UIComponent
{
    [XmlAttribute]
    public float Progress { get; set; }

    [XmlAttribute]
    public string? ProgressColor { get; set; } = null;
}
