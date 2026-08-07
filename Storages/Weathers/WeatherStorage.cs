using WeatherWpfApp.Models;
using WeatherWpfApp.Servises.Weather;

namespace WeatherWpfApp.Storages.Weathers
{
    public class WeatherStorage : IWeatherStorage
    {
        private readonly OpenMeteoProvider openMeteoProvider;

        public WeatherStorage(OpenMeteoProvider openMeteoProvider)
        {
            this.openMeteoProvider = openMeteoProvider;
        }

        public WeatherForecast Get(float latitude, float longitude, ForecastMeasuresModel measures, string name)
        {
            var weather = openMeteoProvider.GetWeather(latitude, longitude, measures);
            weather.Location.Name = name;

            return weather;
        }
    }
}
    