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
            HourlyForecast = new List<HourlyForecastModel>();

            for (int i = 0; i < 24; i++)
            {
                var random = new Random();

                var hour = new HourlyForecastModel
                {
                    Time = new TimeOnly(i, 00),
                    Temperature = random.Next(23, 32),
                    ApparentTemperature = random.Next(13, 22),
                    RelativeHumidity = 0.65f,
                    SurfasePressure = random.Next(745, 768),
                    WindSpeed = random.Next(0, 20),
                    WindDirection = random.Next(1, 9),
                    Weather = (WeatherCodes)random.Next(2),
                };
                HourlyForecast.Add(hour);
            }
        }
    }
}
