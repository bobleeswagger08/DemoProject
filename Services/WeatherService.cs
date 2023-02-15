using Newtonsoft.Json;
using PwcInterview.Models;
namespace PwcInterview.Services;

public interface IWeatherService{
     Task<WeatherInformation> GetWeather(float lat, float lng);
}
public class WeatherService :IWeatherService
{
    WeatherInformation weatherInfo = new();
    HttpClient httpClient;
    public WeatherService()
    {
        this.httpClient = new HttpClient();
    }
    public async Task<WeatherInformation> GetWeather(float lat, float lng){
        
        try{
        var response =   await httpClient.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lng}&current_weather=true");
         if(response.IsSuccessStatusCode){
            var responseBody= await response.Content.ReadAsStringAsync();
            weatherInfo =  JsonConvert.DeserializeObject<WeatherInformation>(responseBody);
         }
       
        }
        catch(Exception ex){
            throw;
        }
         
        return weatherInfo;
    }
    
}