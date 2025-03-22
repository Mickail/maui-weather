using System.Collections.ObjectModel;
using System.Text.Json;
using maui_weather.Models;

namespace maui_weather.ViewModels;

public class CityListViewModel
{
    public ObservableCollection<CityModel> Cities { get; set; } = new();

    public CityListViewModel()
    {
        LoadCities();
    }

    private async void LoadCities()
    {
        try
        {
            // Legge il file JSON dalle risorse
            using var stream = await FileSystem.OpenAppPackageFileAsync("cities.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();

            // Deserializza il JSON in una lista di oggetti CityModel
            var cities = JsonSerializer.Deserialize<List<CityModel>>(json);
            Console.WriteLine($"CITIESSS: count= {cities}");

            if (cities != null)
            {
                foreach (var city in cities)
                {
                    Cities.Add(city);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CITIESSS: Errore nel caricamento delle città: {ex.Message}");
        }
    }
}
