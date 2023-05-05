using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Stetic;

namespace SteticToMauiConverter.Maui.Factories;
public interface IContainersFactory
{
    ContentView CreateContentView(Widget widget);
    Frame CreateFrame(Widget widget);
    HorizontalStackLayout CreateHorizontalStackLayout(Widget widget);
    ScrollView CreateScrollView(Widget widget);
    VerticalStackLayout CreateVerticalStackLayout(Widget widget);
}