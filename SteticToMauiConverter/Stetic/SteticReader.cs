using System.Xml.Serialization;

namespace SteticToMauiConverter.Stetic;
public class SteticReader
{
    private readonly XmlRootAttribute _rootAttribute = new("stetic-interface");

    private readonly XmlSerializer _xmlSerializer;

    public SteticReader()
    {
        _xmlSerializer = new(typeof(SteticInterface), _rootAttribute);
    }
    public SteticInterface Read(string filePath)
    {
        using FileStream fileStream = new(filePath, FileMode.Open);

        var stetic = _xmlSerializer.Deserialize(fileStream);

        if (stetic is SteticInterface result)
        {
            return result;
        }

        throw new InvalidOperationException("Unable to read stetic");
    }
}
