using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components.Tables;
public class TableView : UIComponent
{
    [XmlArray(ElementName = "TableRoot")]
    TableSection[]? TableSections { get; set; } = null;
}
