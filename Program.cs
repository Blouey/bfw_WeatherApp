
using WeatherConsoleApp.Models;

namespace WeatherConsoleApp;

class Program
{
    internal const string Path = @"C:\Repos\bfw_WeatherApp\";

    static void Main(string[] args)
    {
        WeatherFunction wf = new WeatherFunction();
        Console.Clear();
        
        if (!File.Exists(Path + "WeatherData.json"))
        {
            return;
        }
        List<WeatherInfo> weatherInfos = wf.GetDataList(Path + "WeatherData.json");
        
       // wf.PrintWeatherInfo(weatherInfos);

        var date = DateTime.UtcNow.AddHours(+1);
        
        File.WriteAllLines(Path + "WetterResult.txt",
            new string[] { "Wetterdaten: ",date.ToString(), "\n" });
        
        wf.LogAllWeather(weatherInfos);
    }
}