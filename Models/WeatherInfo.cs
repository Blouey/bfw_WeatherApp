namespace WeatherConsoleApp.Models;

public struct WeatherInfo
{
    public string Cityname { get; set; }
    public List<Weather> Weather { get; set; }
    public WeatherInfo(string cityname, Weather weather)
    {
        Cityname = cityname;
        Weather = new List<Weather>();
    }
}

public struct Weather(string date, double[] temperatures, int[] airPressures, double[] humidities, int[] windSpeeds)
{
    public string Date { get; set; } = date;                    //  i.e. "2021-09-01"
    public double[] Temperatures { get; set; } = temperatures;  //  i.e. {12.5, 15.3, 17.2, 19.1, 20.9, 22.8, 24.7, 26.6}
    public int[] AirPressures { get; set; } = airPressures;     //  i.e. {1024, 1023, 1022, 1021, 1020, 1019, 1018, 1017}
    public double[] Humidities { get; set; } = humidities;      //  i.e. {0.75, 0.73, 0.71, 0.69, 0.67, 0.65, 0.63, 0.61}
    public int[] WindSpeeds { get; set; } = windSpeeds;         //  i.e. {5, 6, 7, 8, 9, 10, 11, 12}
}