using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherWpfApp.Models;
using WeatherWpfApp.Storages;

namespace WeatherWpfApp.ViewModels
{
    public class HomeViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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

        public HomeViewViewModel()
        {
            ForecastDays = WeatherDataStorage.Load();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
