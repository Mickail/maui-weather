namespace maui_weather.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnNavigateToCities(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//city-list-page"); // Naviga alla pagina delle città
    }
}

