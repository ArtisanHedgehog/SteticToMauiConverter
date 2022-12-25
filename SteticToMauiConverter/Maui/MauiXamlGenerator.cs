using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Maui.Factories;
using SteticToMauiConverter.Stetic;
namespace SteticToMauiConverter.Maui;

using System.Xml.Serialization;

public class MauiXamlGenerator
{
    private readonly ComponentsFactory _componentsFactory;
    private readonly XmlSerializerNamespaces _namespaces;
    private readonly XmlSerializer _xmlSerializer;

    public MauiXamlGenerator(ComponentsFactory componentsFactory)
    {
        _namespaces = new();
        _namespaces.Add("", Constants.Maui2021);
        _namespaces.Add("x", Constants.Maui2009);

        _xmlSerializer = new(typeof(ContentView));
        _componentsFactory = componentsFactory;
    }

    public void Generate(Widget widget)
    {
        ContentView objectForSerialization = (ContentView)_componentsFactory.CreateComponent(widget)!;

        using FileStream outputFileStream = new($"{widget.Id}.xaml", FileMode.Create);

        _xmlSerializer.Serialize(outputFileStream, objectForSerialization, _namespaces);
    }
}
