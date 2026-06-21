using System.Windows.Input;

namespace WeatherWpfApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand HomeCommand { get; }
        public ICommand LocationCommand { get; }
        public ICommand SettingsCommand { get; }

        private BaseViewModel selectedContent;

        public BaseViewModel SelectedContent
        {
            get {  return selectedContent; }
            set
            {
                selectedContent = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
            LocationCommand = new RelayCommand(OpenLocationView, CanOpenLocationView);
            SettingsCommand = new RelayCommand(OpenSettingsView, CanOpenSettingsView);
        }

        private bool CanOpenHomeView(object arg)
        {
            return true;
        }

        private void OpenHomeView(object obj)
        {
            SelectedContent = new HomeViewViewModel();
        }
        private bool CanOpenLocationView(object arg)
        {
            return true;
        }

        private void OpenLocationView(object obj)
        {
            SelectedContent = new LocationViewViewModel();
        }

        private bool CanOpenSettingsView(object arg)
        {
            return true;
        }

        private void OpenSettingsView(object obj)
        {
            SelectedContent = new SettingsViewViewModel();
        }
    }
}
