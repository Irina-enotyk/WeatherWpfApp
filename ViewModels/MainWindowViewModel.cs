using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WeatherWpfApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand HomeCommand { get; }
        public ICommand LocationCommand { get; }

        private HomeViewViewModel homeViewViewModel;
        public HomeViewViewModel HomeViewViewModel
        {
            get { return homeViewViewModel; }
            set
            {
                homeViewViewModel = value;
                OnPropertyChanged();
            }
        }

        private LocationViewViewModel locationViewViewModel;
        public LocationViewViewModel LocationViewViewModel
        {
            get { return locationViewViewModel; }
            set
            {
                locationViewViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
            LocationCommand = new RelayCommand(OpenLocationView, CanOpenLocationView);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private bool CanOpenHomeView(object arg)
        {
            return true;
        }

        private void OpenHomeView(object obj)
        {
            HomeViewViewModel = new HomeViewViewModel();
        }
        private bool CanOpenLocationView(object arg)
        {
            return true;
        }

        private void OpenLocationView(object obj)
        {
            LocationViewViewModel = new LocationViewViewModel();
        }
    }
}
