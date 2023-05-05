namespace SteticToMauiConverter.Maui;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Maui.Factories;
using SteticToMauiConverter.Stetic;
using System.Xml.Serialization;

public class MauiXamlGenerator
{
    private readonly ContainersFactory _containersFactory;
    private readonly XmlSerializerNamespaces _namespaces;
    private readonly XmlSerializer _xmlSerializer;

    public MauiXamlGenerator(ContainersFactory containersFactory)
    {
        _namespaces = new();
        _namespaces.Add("", Constants.Maui2021);
        _namespaces.Add("x", Constants.Maui2009);

        _xmlSerializer = new(typeof(ContentView));
        _containersFactory = containersFactory;
    }

    public void Generate(Widget widget)
    {
        ContentView objectForSerialization = (ContentView)_containersFactory.CreateComponent(widget)!;

        using FileStream outputFileStream = new($"{widget.Id}.xaml", FileMode.Create);

        _xmlSerializer.Serialize(outputFileStream, objectForSerialization, _namespaces);
    }
}
