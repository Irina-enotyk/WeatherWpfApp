namespace WeatherWpfApp.Models
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
        public WeatherCodes Weather { get; set; }
        public string Location { get; set; }
        public List<HourlyForecastModel> HourlyForecast { get; set; } 

        public DayForecastModel()
        {
            LoadHourlyData();
        }

        private void LoadHourlyData()
        {
            var hour8 = new HourlyForecastModel
            {
                Time = new TimeOnly(8, 00),
                Temperature = 27,
                ApparentTemperature = 26,
                RelativeHumidity = 0.65f,
                SurfasePressure = 765,
                WindSpeed = 3,
                WindDirection = 2,
                Weather = WeatherCodes.SlightRain    
            };
            var hour9 = new HourlyForecastModel
            {
                Time = new TimeOnly(9, 00),
                Temperature = 28,
                ApparentTemperature = 27,
                RelativeHumidity = 0.75f,
                SurfasePressure = 766,
                WindSpeed = 5,
                WindDirection = 3,
                Weather = WeatherCodes.ClearSky    
            };
            var hour10 = new HourlyForecastModel
            {
                Time = new TimeOnly(10, 00),
                Temperature = 26,
                ApparentTemperature = 25,
                RelativeHumidity = 0.73f,
                SurfasePressure = 764,
                WindSpeed = 4,
                WindDirection = 3,
                Weather = WeatherCodes.ClearSky    
            };
            HourlyForecast = new List<HourlyForecastModel> { hour8, hour9, hour10};
        }
    }
}
