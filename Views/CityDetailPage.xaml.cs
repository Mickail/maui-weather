using maui_weather.Models;

namespace maui_weather.Views;

[QueryProperty(nameof(City), "city")]
public partial class CityDetailPage : ContentPage
{
    private CityModel _city;
    public CityModel City
    {
        get => _city;
        set
        {
            _city = value;
            OnPropertyChanged(nameof(City));
        }
    }

    public CityDetailPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
