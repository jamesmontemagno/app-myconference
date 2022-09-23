using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using OpenMap = Microsoft.Maui.ApplicationModel.Map;

namespace MyConference.Pages;

public partial class MapPage : ContentPage
{
    Location location;
	public MapPage()
	{
		InitializeComponent();
        location = new Location(52.092876, 5.104480);
    }

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
        var mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(3));
        map.MoveToRegion(mapSpan);
        map.Pins.Add(new Pin
        {
            Label = "Techorama",
            Location = location,
        });
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await OpenMap.TryOpenAsync(location, new MapLaunchOptions
        {
            Name = "Techorama",
            NavigationMode = NavigationMode.None
        });
    }
}