using PwcInterview.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace PwcInterview;
public class StartUp
{
 public static IServiceProvider ConfigurationService(){
    var provider = new ServiceCollection()
                     .AddSingleton<IWeatherService, WeatherService>()
                     .AddTransient<ICityCordinateService, CityCordinateService>()
                     .BuildServiceProvider();
    return provider;

 }

}