using WeatherWpfApp.Models;

namespace WeatherWpfApp.Servises.Weather
{
    public class DailyApiResponse
    {
        //Почему тут используется стиль имен переменных с подчёркиванием?
        //Раньше был только CamelCase

        public DailyResponseBody? Daily {  get; set; }
        public HourlyResponseBody? Hourly {  get; set; }
    }

    public class DailyResponseBody
    {
        public List<DateTime> Time { get; set; }
        public List<float>? Temperature_2m_max { get; set; }
        public List<float>? Temperature_2m_min { get; set; }
        public List<int>? Weathercode { get; set; }
        public List<float>? Windspeed_10m_max { get; set; }
        public List<int>? Winddirection_10m_dominantion { get; set; }
    }

    public class HourlyResponseBody
    {
        public List<DateTime> Time { get; set; }
        public List<float>? Temperature_2m { get; set; }
        public List<float>? Apparent_temperature { get; set; }
        public List<float>? Windspeed_10m { get; set; }
        public List<float>? Relaitivehumidity { get; set; }
        public List<float>? Surface_pressure { get; set; }
        public List<int>? Weathercode { get; set; }
        public List<int>? Winddirection_10m_dominantion { get; set; }
    }
}