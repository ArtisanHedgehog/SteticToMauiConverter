using SteticToMauiConverter.Maui;
using SteticToMauiConverter.Stetic;

SteticReader _steticReader = new();
MauiXamlGenerator _mauiXamlGenerator = new();

Console.WriteLine("Stetic to maui converter!");

var source = _steticReader.Read("gui.stetic");

var componentsToGenerate = source.GetComponentWidgets();

Console.WriteLine("This components will be generated:");

foreach (var widgetClass in componentsToGenerate.Select(w => w.Id))
{
    Console.WriteLine(widgetClass);
}

Console.WriteLine();

foreach (var component in componentsToGenerate)
{
    _mauiXamlGenerator.Generate(component);
}

Console.WriteLine("Done!");
