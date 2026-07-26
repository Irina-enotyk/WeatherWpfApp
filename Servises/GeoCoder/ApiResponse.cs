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
        public string Name { get; set; }
        public string Description { get; set; }
        public Point Point { get; set; }
    }

    public class Point
    {
        public string Pos { get; set; }
    }
}