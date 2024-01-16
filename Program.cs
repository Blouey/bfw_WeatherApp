using System.Text;
using WeatherConsoleApp.Models;

namespace WeatherConsoleApp;

class Program
{
    internal const string Path = @"C:\Repos\WeatherConsoleApp\";

    static void Main(string[] args)
    {
        Console.Clear();

        WeatherFunction wf = new WeatherFunction();

        if (!File.Exists(Path + "WeatherData.json"))
        {
            return;
        }

        List<WeatherInfo> weatherInfos = wf.GetDataList(Path + "WeatherData.json");

        wf.LogWeatherInfo(weatherInfos);

        /*
        File.WriteAllLines(Path + "WetterResult.txt",
            new string[] { "Wetterdaten: ", date.ToString(), "\n" });
        */
        // wf.PrintWeatherInfo(weatherInfos); 
        // wf.LogAllWeather(weatherInfos);
    }
}