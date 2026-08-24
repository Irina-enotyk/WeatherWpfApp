namespace WeatherWpfApp.Servises.GeoCoder
{
    public class ApiResponse
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public GeoObjectCollection GeoObjectCollection { get; set; }
    }

    public class GeoObjectCollection
    {
        public FeatureMember[] FeatureMember { get; set; }
    }

    public class FeatureMember
    {
        public GeoObject GeoObject { get; set; }
    }

    public class GeoObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public GeoPoint Point { get; set; }
    }

    public class GeoPoint
    {
        public string Pos { get; set; }
    }
}