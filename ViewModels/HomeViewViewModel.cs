using WeatherWpfApp.Models;

namespace WeatherWpfApp.ViewModels
{
    public class HomeViewViewModel : BaseViewModel
    {
        private List<DayForecastModel> forecastDays;

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

        public HomeViewViewModel(IWeatherStorage weatherStorage)
        {
            ForecastDays = weatherStorage.GetAll();
        }
    }
}
