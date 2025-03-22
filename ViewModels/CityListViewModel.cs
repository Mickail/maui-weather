using System.Collections.ObjectModel;
using System.Text.Json;
using maui_weather.Models;
using System.Linq;

namespace maui_weather.ViewModels;

public class CityListViewModel
{
    private string _searchText = string.Empty;
    private List<CityModel> _allCities = [];

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                FilterCities();
            }
        }
    }

    public ObservableCollection<CityModel> FilteredCities { get; set; } = new();

    public CityListViewModel()
    {
        LoadCities();
    }

    private async void LoadCities()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("cities.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();

            var cities = JsonSerializer.Deserialize<List<CityModel>>(json);
            if (cities != null)
            {
                _allCities = cities;
                FilterCities();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading cities: {ex.Message}");
        }
    }

    private void FilterCities()
    {
        var filtered = string.IsNullOrWhiteSpace(SearchText)
            ? _allCities
            : _allCities.Where(c => c.name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();

        // ObservableCollection --> forzo l'aggiornamento della UI pulento e riempiendo FilteredCities
        FilteredCities.Clear();
        foreach (var city in filtered)
        {
            FilteredCities.Add(city);
        }
    }
}
