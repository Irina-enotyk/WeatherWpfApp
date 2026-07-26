
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;

namespace WeatherWpfApp.Servises.GeoCoder
{
    public class GeoCoderService
    {
        private readonly string apikey = LoadApiKey();
        private readonly HttpClient httpClient = new HttpClient();

        private static string LoadApiKey()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "apikey.txt");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    "Не найден файл apikey.txt с ключом API Яндекс Геокодера. " +
                    "Скопируйте apikey.txt.sample в apikey.txt и вставьте свой ключ.",
                    path);
            }

            return File.ReadAllText(path).Trim();
        }

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
