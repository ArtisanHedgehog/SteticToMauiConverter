using Microsoft.VisualBasic;
using SteticToMauiConverter.Maui;
using SteticToMauiConverter.Stetic;
using System.Diagnostics;
using System.Xml.Serialization;

ComponentsFactory _componentsFactory = new();

Console.WriteLine("Stetic to maui converter!");

XmlRootAttribute steticRoot = new("stetic-interface");

XmlSerializer xmSourceSerializer = new(typeof(SteticInterface), steticRoot);

using FileStream fileStream = new("gui.stetic", FileMode.Open);

SteticInterface source = ((SteticInterface?)xmSourceSerializer.Deserialize(fileStream))
    ?? throw new InvalidOperationException("Unable to serialize stetic");

var componentsToGenerate = source.GetComponentWidgets();

Console.WriteLine("This components will be generated:");

foreach (var widgetClass in componentsToGenerate.Select(w => w.Id))
{
    Console.WriteLine(widgetClass);
}

Console.WriteLine();

XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

ns.Add("", SteticToMauiConverter.Maui.Constants.Maui2021);
ns.Add("x", SteticToMauiConverter.Maui.Constants.Maui2009);

XmlSerializer contentViewSerializer = new(typeof(ContentView));

foreach (var component in componentsToGenerate)
{
    ContentView objectForSerialization = (ContentView)_componentsFactory.CreateComponent(component)!;

    using FileStream outputFileStream = new($"{component.Id}.xaml", FileMode.Create);

    contentViewSerializer.Serialize(outputFileStream, objectForSerialization, ns);
}

Console.WriteLine("Done!");
