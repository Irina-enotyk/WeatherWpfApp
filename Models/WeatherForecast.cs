using WeatherWpfApp.Servises.GeoCoder;

namespace WeatherWpfApp.Models
{
    public class WeatherForecast
    {
        public GeoLocation Location {  get; set; }
        public TemperatureMeasure TemperatureMeasure { get; set; }

        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }

        public List<DayForecastModel> DayForecasts { get; set; } = new List<DayForecastModel>();
    }
}