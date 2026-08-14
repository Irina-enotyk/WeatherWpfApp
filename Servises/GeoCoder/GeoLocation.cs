using Microsoft.EntityFrameworkCore;

namespace WeatherWpfApp.Servises.GeoCoder
{
    [PrimaryKey("Latitude", "Longitude")]

    public class GeoLocation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

    }
}