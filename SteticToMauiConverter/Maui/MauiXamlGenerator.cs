using SteticToMauiConverter.Stetic;
using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;
public class MauiXamlGenerator
{
    private readonly XmlSerializerNamespaces _namespaces = new();

    private readonly XmlSerializer _xmlSerializer;

    private readonly ComponentsFactory _componentsFactory = new();

    public MauiXamlGenerator()
    {
        _namespaces.Add("", SteticToMauiConverter.Maui.Constants.Maui2021);
        _namespaces.Add("x", SteticToMauiConverter.Maui.Constants.Maui2009);

        _xmlSerializer = new(typeof(ContentView));
    }

    public void Generate(Widget widget)
    {
        ContentView objectForSerialization = (ContentView)_componentsFactory.CreateComponent(widget)!;

        using FileStream outputFileStream = new($"{widget.Id}.xaml", FileMode.Create);

        _xmlSerializer.Serialize(outputFileStream, objectForSerialization, _namespaces);
    }
}
