using WeatherWpfApp.Models;
using WeatherWpfApp.Servises.GeoCoder;

namespace WeatherWpfApp.Servises.Settings
{
    public class Settings
    {
        public Cultures Cultures { get; set; }
        public TemperatureMeasure TemperatureMeasure { get; set; }
        public GeoLocation SelectedLocation { get; set; } = new GeoLocation
        {
            Name = "Санкт-Петербург",
            Longitude = 59.938676,
            Latitude = 30.314494,
        };
    }
}
