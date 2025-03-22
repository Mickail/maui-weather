namespace maui_weather.Models;

public class CityModel
{
    public int id { get; set; }
    public string name { get; set; }
    public string state { get; set; }
    public string country { get; set; }
    public Coordinates coord { get; set; }
}

public class Coordinates
{
    public double lon { get; set; }
    public double lat { get; set; }
}