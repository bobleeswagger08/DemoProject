
using System;

namespace DemoProject.Models;
public class WeatherInformation
{
    public float latitude { get; set; }
    public float longitude { get; set; }
    public decimal generationtime_ms { get; set; }
    public decimal utc_offset_seconds { get; set; }
    public string timezone { get; set; }
    public string timezone_abbreviation { get; set; }
    public string elevation { get; set; }
     public CurrentWeather current_weather{get;set;}

};
public class CurrentWeather {
    public float temperature { get; set; }
    public float windspeed { get; set; }
    public string winddirection { get; set; }
    public int weathercode { get; set; }
    public string time { get; set; }

}