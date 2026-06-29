namespace WeatherWpfApp.Models
{
    public class HourlyForecastModel
    {
        public TimeOnly Time { get; set; }
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float RelativeHumidity { get; set; }
        public float SurfasePressure { get; set; }
        public float WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public WeatherCodes Weather { get; set; }
    }
}
