﻿using System.Xml.Serialization;

namespace SteticToMauiConverter.Maui.Components;
public class RadioButton : UIComponent
{
    [XmlAttribute]
    public string? GroupName { get; set; }
}