using System.Windows;
using System.Windows.Input;

namespace WeatherWpfApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand HomeCommand { get; }
        public ICommand LocationCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand CloseCommand { get; }

        private BaseViewModel selectedContent;

        private HomeViewViewModel homeViewViewModel;

        public BaseViewModel SelectedContent
        {
            get {  return selectedContent; }
            set
            {
                selectedContent = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(HomeViewViewModel homeViewViewModel)
        {
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
            LocationCommand = new RelayCommand(OpenLocationView, CanOpenLocationView);
            SettingsCommand = new RelayCommand(OpenSettingsView, CanOpenSettingsView);
            CloseCommand = new RelayCommand(CloseApplication, CanOpenCloseApplication);
            this.homeViewViewModel = homeViewViewModel;
        }

        private bool CanOpenHomeView(object arg)
        {
            return true;
        }

        private void OpenHomeView(object obj)
        {
            SelectedContent = homeViewViewModel;
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

        private bool CanOpenCloseApplication(object arg)
        {
            return true;
        }

        private void CloseApplication(object obj)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
