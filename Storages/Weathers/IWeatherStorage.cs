using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages.Weathers
{

    public interface IWeatherStorage
    {
        WeatherForecast Get(float latitude, float longitude, ForecastMeasuresModel measures, string name);
    }
}