using WeatherWpfApp.Models;

public interface IWeatherStorage
{
    public List<DayForecastModel> GetAll();
}
