using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "3ecc1f2320902bc3d5202ba51d66dc62";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&appid=" + key + "&units=imperial";
            JObject results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];
                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                // added
                weather.HighTemp = (string)results["main"]["temp_max"] + " F";
                weather.LowTemp = (string)results["main"]["temp_min"] + " F";
                weather.AirPressure = (string)results["main"]["pressure"] + " hPa";
                weather.WindDirection = (string)results["wind"]["deg"] + " Degress";

                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}