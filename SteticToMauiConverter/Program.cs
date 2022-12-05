using SteticToMauiConverter.Maui;
using SteticToMauiConverter.Stetic;
using System.Diagnostics;
using System.Xml.Serialization;

Console.WriteLine("Stetic to maui converter!");

XmlRootAttribute steticRoot = new("stetic-interface");

XmlSerializer xmSourceSerializer = new(typeof(SteticInterface), steticRoot);

using FileStream fileStream = new("gui.stetic", FileMode.Open);

SteticInterface source = ((SteticInterface?)xmSourceSerializer.Deserialize(fileStream))
    ?? throw new InvalidOperationException("Unable to serialize stetic");

//PrintUniqueWidgetsClasses(source);
//PrintIds(source);

var componentsToGenerate = GetComponentsClassNames(source);
Console.WriteLine("This components will be generated:");
PrintStrings(componentsToGenerate);
Console.WriteLine();


XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

ns.Add("", SteticToMauiConverter.Maui.Constants.Maui2021);
ns.Add("x", SteticToMauiConverter.Maui.Constants.Maui2009);

XmlSerializer contentViewSerializer = new(typeof(ContentView));

foreach (var component in componentsToGenerate)
{
    var objectForSerialization = new ContentView
    {
        Class = component
    };

    using FileStream outputFileStream = new($"{component}.xaml", FileMode.OpenOrCreate);

    contentViewSerializer.Serialize(outputFileStream, objectForSerialization, ns);
}

Console.WriteLine("Done!");


static void PrintStrings(IEnumerable<string> strings)
{
    foreach (var widgetClass in strings)
    {
        Console.WriteLine(widgetClass);
    }
}

static IEnumerable<string> GetComponentsClassNames(SteticInterface steticInterface)
{
    return steticInterface.Widgets?.Where(w =>
                w.Class == SteticToMauiConverter.Stetic.Constants.Classes.Widget)
            .Select(w => w.Id ?? "")
            ?? throw new InvalidOperationException("There is no widgets!!");
}

static void PrintIds(SteticInterface steticInterface)
{
    Console.WriteLine();
    Console.WriteLine("Main widgets Ids:");
    PrintStrings(GetMainWidgetsIds(steticInterface));
}

static IEnumerable<string> GetMainWidgetsIds(SteticInterface steticInterface)
{
    return steticInterface.Widgets?.Select(w => w.Id ?? "")
        ?? throw new InvalidOperationException("There is no widgets!!");
}

[Conditional("DEBUG")]
static void PrintUniqueWidgetsClasses(SteticInterface steticInterface)
{
    Console.WriteLine();
    Console.WriteLine("Founded widgets classes:");
    PrintStrings(GetUniqueClasses(steticInterface));
}

static IEnumerable<string> GetUniqueClasses(SteticInterface steticInterface)
{
    return steticInterface.Widgets?
                    .Select(GetClasses)
                    .SelectMany(en => en)
                    .Distinct()
                    .OrderBy(x => x)
                    ?? throw new InvalidOperationException("Unable to find classes");
}

static IEnumerable<string> GetClasses(Widget? widget)
{
    if (widget is null)
    {
        return Enumerable.Empty<string>();
    }

    string currentClass = widget.Class ?? "";

    List<string> classes = new();

    if (widget.Childs is not null && widget.Childs.Length > 0)
    {
        classes.AddRange(
            widget.Childs.SelectMany(child => GetClasses(child.Widget)));
    }

    classes.Add(currentClass);

    return classes;
}
