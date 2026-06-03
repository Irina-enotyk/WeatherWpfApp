namespace WeatherWpfApp
{
    public class DayForecastModel
    {
        public DateTime Date { get; set; }
        public string WeekDay { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float Pressure { get; set; }
        public float WindSpeed { get; set; }
        public WindDirection WindDirection { get; set; }
        public WeatherCodes Wheather { get; set; }
        public string Location { get; set; }
    }

    public enum WeatherCodes
    {
        ClearSky = 0,
        Windy = 1,
        Overcast = 2,
        Fog = 3,
        SlightRain = 4,
        HeavyRain = 5,
        Snowfall = 6,
        Thunderstorm = 7
    }

    public enum WindDirection
    {
        West,
        East,
        Nord,
        Sud
    }
}
