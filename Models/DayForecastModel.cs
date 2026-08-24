namespace WeatherWpfApp.Models
{
    public class DayForecastModel
    {
        public DateTime Date { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float WindSpeed { get; set; }
        public WindDirection WindDirection { get; set; }
        public WeatherCodes Weather { get; set; }
        public List<HourlyForecastModel> HourlyForecast { get; set; } = new List<HourlyForecastModel>();
    }
}
