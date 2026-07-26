
using System.Net.Http;
using System.Net.Http.Json;

namespace WeatherWpfApp.Servises.GeoCoder
{
    public class GeoCoderService
    {
        private const string apikey = "67303047-9d38-49b7-a1fe-4e79406f0655";
        private readonly HttpClient httpClient = new HttpClient();

        public List<GeoLocation> GetLocations (string place)
        {
            var url = $"https://geocode-maps.yandex.ru/1.x/?apikey={apikey}&geocode={place}&format=json";

            var response = httpClient.GetFromJsonAsync<ApiResponse>(url).Result;

            return ToGeoLocation(response);
        }

        private List<GeoLocation> ToGeoLocation(ApiResponse? response)
        {
            var locations = new List<GeoLocation>();

            foreach (var item in response.Response.GeoObjectCollection.FeatureMember)
            {
                var location = new GeoLocation();

                location.Name = item.Name;
                location.Description = item.Description;

                var points = item.Point.Pos.Split(" ");

                location.Longitude = Convert.ToDouble(points[0]);
                location.Latitude = Convert.ToDouble(points[1]);

                locations.Add(location);
            }
            return locations;
        }
    }
}
