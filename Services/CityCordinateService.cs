using System.Text.Json;
using System.IO;
using DemoProject.Models;
namespace DemoProject.Services;

public interface ICityCordinateService{
     Task<CityCordinates> GetCityDetails(string cityName);
}
public class CityCordinateService :ICityCordinateService
{
    CityCordinates cityInfo = new();
    public async Task<CityCordinates> GetCityDetails(string cityName){
       try{ 
        string text = await File.ReadAllTextAsync(@"./Assets/in.json");
        var cityDetails = JsonSerializer.Deserialize<IEnumerable<CityCordinates>>(text);
        cityInfo = cityDetails.Where(i=>i.city.ToLower()==cityName.ToLower()).FirstOrDefault();
         
        return cityInfo;
        }
        catch(Exception ex){
            throw;
        }
    }
    
}
