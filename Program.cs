namespace WeatherConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        if (!File.Exists("WetterWerte.txt"))
        {
            return;
        }
        
        string[] allLines = File.ReadAllLines("WetterWerte.txt");
            
        File.WriteAllLines("C:\\Repos\\WeatherConsoleApp\\WetterResult.txt", allLines);
    }
}