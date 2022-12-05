﻿using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui;

[XmlRoot(Namespace = Constants.Maui2021)]
public class ContentView : UIComponent
{
    [XmlAttribute("Class", Namespace = Constants.Maui2009)]
    public string Class { get; set; } = null!;

    [XmlElement(typeof(VerticalStackLayout), ElementName = nameof(VerticalStackLayout))]
    [XmlElement(typeof(HorizontalStackLayout), ElementName = nameof(HorizontalStackLayout))]
    public UIComponent[]? UIComponents { get; set; }
}
