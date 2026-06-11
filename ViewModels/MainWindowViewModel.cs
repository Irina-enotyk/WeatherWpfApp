using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WeatherWpfApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand HomeCommand { get; }

        public HomeViewViewModel HomeViewViewModel
        {
            get { return homeViewViewModel; }
            set
            {
                homeViewViewModel = value;
                OnPropertyChanged();
            }
        }

        private HomeViewViewModel homeViewViewModel;

        public MainWindowViewModel()
        {
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
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
            homeViewViewModel = new HomeViewViewModel();
        }
    }
}
