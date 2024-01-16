using System.Text.Json;
using WeatherConsoleApp.Models;

namespace WeatherConsoleApp;

public class WeatherFunction
{
    public List<WeatherInfo> GetDataList(string path)
    {
        if(File.Exists(path))
        {
            return JsonSerializer.Deserialize<List<WeatherInfo>>(File.ReadAllText(path))!;
        }

        return new List<WeatherInfo>();
    }
    
    public string AnalyzeTemps(double[] temps)
    {
        double min = temps[0];
        double max = temps[0];
        double sum = 0;
        foreach (double temp in temps)
        {
            if (temp < min)
            {
                min = temp;
            }
            if (temp > max)
            {
                max = temp;
            }
            sum += temp;
        }
        return $"Temperatures: \n\t-------------- \n\tMin: {min}\u00b0C \n\tMax: {max}\u00b0C \n\tAvg: {Math.Round(((decimal)sum / temps.Length),2)}\u00b0C \n";
    }
    
    public string AnalyzeAirPressures(int[] airPressures)
    {
        int min = airPressures[0];
        int max = airPressures[0];
        int sum = 0;
        foreach (int airPressure in airPressures)
        {
            if (airPressure < min)
            {
                min = airPressure;
            }
            if (airPressure > max)
            {
                max = airPressure;
            }
            sum += airPressure;
        }
        return $"AirPressures: \n\t-------------- \n\tMin: {min} mbar \n\tMax: {max} mbar \n\tAvg: {Math.Round(((decimal)sum / airPressures.Length), 2)} mbar \n";
    }
    
    public string AnalyzeHumidities(double[] humidities)
    {
        double min = humidities[0];
        double max = humidities[0];
        double sum = 0;
        foreach (double humidity in humidities)
        {
            if (humidity < min)
            {
                min = humidity;
            }
            if (humidity > max)
            {
                max = humidity;
            }
            sum += humidity;
        }
        min *= 100;
        max *= 100;
        sum *= 100;
        return $"Humidities: \n\t-------------- \n\tMin: {(int)min}% \n\tMax: {(int)max}% \n\tAvg: {Math.Round(((decimal)sum / humidities.Length), 2)}% \n";
    }
    
    public string AnalyzeWindSpeeds(int[] windSpeeds)
    {
        int min = windSpeeds[0];
        int max = windSpeeds[0];
        int sum = 0;
        foreach (int windSpeed in windSpeeds)
        {
            if (windSpeed < min)
            {
                min = windSpeed;
            }
            if (windSpeed > max)
            {
                max = windSpeed;
            }
            sum += windSpeed;
        }
        return $"WindSpeeds: \n\t--------------  \n\tMin: {min} km/h \n\tMax: {max} km/h \n\tAvg: {Math.Round(((decimal)sum / windSpeeds.Length), 2)} km/h \n";
    }
    
    public void PrintWeatherInfo(List<WeatherInfo> weatherList)
    {
        foreach (WeatherInfo weatherInfo in weatherList)
        {
            PrintWeatherInfo(weatherInfo);
        }
    }
    
    public void PrintWeatherInfo(WeatherInfo weatherInfo)
    {
        Console.WriteLine($"______________________ \nCity: {weatherInfo.Cityname}");
        foreach (Weather weather in weatherInfo.Weather)
        {
            Console.WriteLine($"---------------------- \nDate: {weather.Date}");
            Console.WriteLine(AnalyzeTemps(weather.Temperatures));
            Console.WriteLine(AnalyzeAirPressures(weather.AirPressures));
            Console.WriteLine(AnalyzeHumidities(weather.Humidities));
            Console.WriteLine(AnalyzeWindSpeeds(weather.WindSpeeds));
        }
    }
    
    public void LogAllWeather(List<WeatherInfo> weatherList)
    {
        string data = "";
        foreach (WeatherInfo weatherInfo in weatherList)
        {
            data += $"______________________ \nCity: {weatherInfo.Cityname}\n";
            foreach (Weather weather in weatherInfo.Weather)
            {
                data += $"---------------------- \nDate: {weather.Date}\n";
                data += "\n" + AnalyzeTemps(weather.Temperatures);
                data += "\n" + AnalyzeAirPressures(weather.AirPressures);
                data += "\n" + AnalyzeHumidities(weather.Humidities);
                data += "\n" + AnalyzeWindSpeeds(weather.WindSpeeds);
            }
        }
        File.AppendAllText(Program.Path + "WetterResult.txt", data);
    }

    public void LogWeatherInfo(List<WeatherInfo> weatherInfos)
    {
        var date = DateTime.UtcNow.AddHours(+1);
        foreach (WeatherInfo weatherInfo in weatherInfos)
        {
            File.WriteAllLines(Program.Path + $"Wetter{weatherInfo.Cityname}.txt", 
                new string[] { $"Wetterdaten {weatherInfo.Cityname}: ", date.ToString(), "\n" });
            LogCityWeather(weatherInfos, weatherInfo.Cityname);
        }
    }
    
    public void LogCityWeather(List<WeatherInfo> weatherList, string cityname)
    {
        string data = "";
        foreach (WeatherInfo weatherInfo in weatherList)
        {
            if (weatherInfo.Cityname == cityname)
            {
                foreach (Weather weather in weatherInfo.Weather)
                {
                    data += $"______________________ \n\nDate: {weather.Date} \n----------------------\n";
                    data += "\n" + AnalyzeTemps(weather.Temperatures);
                    data += "\n" + AnalyzeAirPressures(weather.AirPressures);
                    data += "\n" + AnalyzeHumidities(weather.Humidities);
                    data += "\n" + AnalyzeWindSpeeds(weather.WindSpeeds);
                }
            }
        }
        File.AppendAllText(Program.Path + $"Wetter{cityname}.txt", data);
    }
}