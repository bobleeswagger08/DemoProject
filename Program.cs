using Microsoft.Extensions.DependencyInjection;
using PwcInterview.Services;
namespace PwcInterview
{

    class Program
    {

        static void Main(string[] args)
        {
            var confirm = "";
            try
            {
                do
                {
                    Console.WriteLine("What is your city2?");
                    var cityName = Console.ReadLine();
                    var container = StartUp.ConfigurationService();
                    var cityService = container.GetRequiredService<ICityCordinateService>();
                    var cityDetails = cityService.GetCityDetails(cityName);
                    var weatherService = container.GetRequiredService<IWeatherService>();
                    if (cityDetails.Result is null)
                    {
                        Console.WriteLine("Please enter a valid city name");
                        confirm = "y";
                        continue;
                    }
                    var weatherInfo = weatherService.GetWeather(float.Parse(cityDetails.Result.lat), float.Parse(cityDetails.Result.lng));

                    var currentDate = DateTime.Now;
                    Console.WriteLine($"{Environment.NewLine}Hello, {cityDetails?.Result.city}, on {currentDate:d} weather is as follows: ");
                    Console.WriteLine($"{Environment.NewLine}Temperature: {weatherInfo.Result.current_weather.temperature} ,Wind Speed :{weatherInfo.Result.current_weather.windspeed}!");
                    Console.WriteLine("\nDo you want to know another city weather? Please enter y/n");
                    confirm = Console.ReadLine();
                } while (confirm == "y");

                Console.Write($"{Environment.NewLine}Press any key to exit...");
                Console.ReadKey(true);
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Null reference exception");
            }
            catch (Exception ex2)
            {
                throw;
            }
        }
    }
}