using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Deserializing_JSON_OpenWeatherMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your api key: ");
            var api_key = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            var cityName = "Birmingham";
            var client = new HttpClient();
            var forecast = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={api_key}&units=imperial";
            var response = client.GetStringAsync(forecast).Result;
            Console.WriteLine(response);
            //var root = JsonConvert.DeserializeObject<Root>(response);
            //var x = 0;
            //foreach (var item in root.List)
            //{
            //    Console.WriteLine( x++ + $"\tTemperature: {item.Main.Temp}");                
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
        }
    }

    public class Root
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<ListItem> List { get; set; }
        public City City { get; set; }
    }

    public class ListItem
    {
        public int Dt { get; set; }
        public Main Main { get; set; }
        public List<WeatherItem> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Sys Sys { get; set; }
        public string Dt_txt { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Sea_level { get; set; }
        public int Grnd_level { get; set; }
        public int Humidity { get; set; }
        public double Temp_kf { get; set; }
    }

    public class Sys
    {
        public string Pod { get; set; }
    }

    public class WeatherItem
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }
}
