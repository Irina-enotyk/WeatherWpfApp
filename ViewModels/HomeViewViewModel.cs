using WeatherWpfApp.Models;
using WeatherWpfApp.Servises.Settings;
using WeatherWpfApp.Storages.Weathers;

namespace WeatherWpfApp.ViewModels
{
    public class HomeViewViewModel : BaseViewModel
    {
        private readonly IWeatherStorage weatherStorage;
        private readonly ISettingsServise settingsServise;
        private List<DayForecastModel> forecastDays;

        private WeatherForecast currentWeather;

        public List<DayForecastModel> ForecastDays
        {
            get => forecastDays;
            set
            {
                forecastDays = value;
                OnPropertyChanged();
            }
        }

        private DayForecastModel selectedDay;

        public DayForecastModel SelectedDay
        {
            get => selectedDay;
            set
            {
                selectedDay = value;
                OnPropertyChanged();
            }
        }

        public HomeViewViewModel(IWeatherStorage weatherStorage, ISettingsServise settingsServise)
        {
            this.weatherStorage = weatherStorage;
            this.settingsServise = settingsServise;
        }

        internal void TryUpdateWeather()
        {
            var settings = settingsServise.Settings;
            var selectedLocaltion = settings.SelectedLocation;

            if(currentWeather == null ||
               currentWeather.Location.Latitude != selectedLocaltion.Latitude ||
               currentWeather.Location.Longitude != selectedLocaltion.Longitude)
            {
                var weather = weatherStorage.Get
                    (selectedLocaltion.Latitude,
                    selectedLocaltion.Longitude,
                    new ForecastMeasuresModel { TemperatureMeasure = settings.TemperatureMeasure },
                    selectedLocaltion.Name);

                currentWeather = weather;
                ForecastDays = weather.DayForecasts;
            }
        }
    }
}
