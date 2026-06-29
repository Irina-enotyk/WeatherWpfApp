using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherWpfApp.Models;
using WeatherWpfApp.Storages;

namespace WeatherWpfApp.ViewModels
{
    public class HomeViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<DayForecastModel> ForecastDays
        {
            get => forecastDays;
            set
            {
                forecastDays = value;
                OnPropertyChanged();
            }
                
        }

        public HomeViewViewModel()
        {
            ForecastDays = WeatherDataStorage.Load();
        }

        private List<DayForecastModel> forecastDays;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
