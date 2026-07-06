using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages.Weathers
{

    public interface IWeatherStorage
    {
        public List<DayForecastModel> GetAll();
    }
}