using System.Windows;
using System.Windows.Input;
using WeatherWpfApp.Storages;

namespace WeatherWpfApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand HomeCommand { get; }
        public ICommand LocationCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand SignInCommand { get; }
        public ICommand SignOutCommand { get; }

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
            CloseCommand = new RelayCommand(CloseApplication, CanCloseApplication);

            RegisterCommand = new RelayCommand(Register, CanRegister);
            SignInCommand = new RelayCommand(SignIn, CanSignIn);
            SignOutCommand = new RelayCommand(SignOut, CanSignOut);

            this.homeViewViewModel = homeViewViewModel;
        }

        private void SignOut(object obj)
        {
            //userStorage.ResetUser();
            //ShowUser();
        }

        private bool CanSignOut(object arg)
        {
            return true;
        }

        private bool CanSignIn(object arg)
        {
            return true;
        }

        private void SignIn(object obj)
        {
            var signInWindow = new SignInWindow();
            signInWindow.ShowDialog();
            //ShowUser();
        }

        private bool CanRegister(object arg)
        {
            return true;
        }

        private void Register(object obj)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
            //ShowUser();
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

        private bool CanCloseApplication(object arg)
        {
            return true;
        }

        private void CloseApplication(object obj)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
