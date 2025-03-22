using maui_weather.Models;

namespace maui_weather.Views;

public partial class CityListPage : ContentPage
{

	public CityListPage()
	{
		InitializeComponent();
	}

	private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is CityModel city)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "city", city }
            };
            await Shell.Current.GoToAsync("//city-detail-page", navigationParameter);
        }
    }

}