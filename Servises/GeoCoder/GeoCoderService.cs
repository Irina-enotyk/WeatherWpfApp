
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using WeatherWpfApp.Storages;

namespace WeatherWpfApp.Servises.GeoCoder
{
    public class GeoCoderService
    {
        private readonly string apikey = LoadApiKey();
        private readonly HttpClient httpClient = new HttpClient();
        private readonly DatabaseContext databaseContext;

        public GeoCoderService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

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
            //поисковая строка является подстрокой имени Location - ов, найденных в бд
            var existingLocations = databaseContext.Locations.Where(x => x.Name.Contains(place)).ToList();
            if (existingLocations.Count > 0)
            {
                return existingLocations;
            }

            var url = $"https://geocode-maps.yandex.ru/1.x/?apikey={apikey}&geocode={place}&format=json";

            var response = httpClient.GetFromJsonAsync<ApiResponse>(url).Result;

            var geolocations = ToGeoLocation(response);

            WhriteDataToBD(geolocations);

            return geolocations;
        }

        private void WhriteDataToBD(List<GeoLocation> geolocations)
        {
            foreach (var location in geolocations)
            {
                //класссс!))
                databaseContext.Locations.Add(location);
            }
            //после любых действий с таблицей бд - сохранить все изменения
            databaseContext.SaveChanges();
        }

        private List<GeoLocation> ToGeoLocation(ApiResponse? response)
        {
            var locations = new List<GeoLocation>();

            foreach (var item in response.Response.GeoObjectCollection.FeatureMember)
            {
                var location = new GeoLocation();

                location.Name = item.GeoObject.Name;
                location.Description = item.GeoObject.Description;

                var points = item.GeoObject.Point.Pos.Split(" ");

                location.Longitude = float.Parse(points[0], CultureInfo.InvariantCulture);
                location.Latitude = float.Parse(points[1], CultureInfo.InvariantCulture);

                locations.Add(location);
            }
            return locations;
        }
    }
}
