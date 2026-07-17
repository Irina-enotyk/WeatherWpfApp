using System.Windows;
using System.Windows.Input;
using WeatherWpfApp.Models;
using WeatherWpfApp.Servises.Localizations;
using WeatherWpfApp.Servises.Settings;
using WeatherWpfApp.Storages.Users;
using WeatherWpfApp.ViewModels.Auth;

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

        private readonly HomeViewViewModel homeViewViewModel;
        private readonly SignInWindowViewModel signInWindowViewModel;
        private readonly RegistrationWindowViewModel registrationWindowViewModel;
        private readonly SettingsViewViewModel settingsViewViewModel;

        private readonly IUserStorage userStorage;
        private readonly ILocalizationServise localizationServise;
        private readonly ISettingsServise settingsServise;
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

        private bool registerButtonIsVisible;
        public bool RegisterButtonIsVisible
        {
            get => registerButtonIsVisible;
            set
            {
                registerButtonIsVisible = value;
                OnPropertyChanged();
            }
        }

        private bool signInButtonIsVisible;
        public bool SignInButtonIsVisible
        {
            get => signInButtonIsVisible;
            set
            {
                signInButtonIsVisible = value;
                OnPropertyChanged();
            }
        }

        private bool signOutButtonIsVisible;
        public bool SignOutButtonIsVisible
        {
            get => signOutButtonIsVisible;
            set
            {
                signOutButtonIsVisible = value;
                OnPropertyChanged();
            }
        }
        private bool userNameLabelIsVisible;
        public bool UserNameLabelIsVisible
        {
            get => userNameLabelIsVisible;
            set
            {
                userNameLabelIsVisible = value;
                OnPropertyChanged();
            }
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel
            (IUserStorage userStorage,
            ILocalizationServise localizationServise,
            HomeViewViewModel homeViewViewModel,
            RegistrationWindowViewModel registrationWindowViewModel,
            SignInWindowViewModel signInWindowViewModel,
            ISettingsServise settingsServise,
            SettingsViewViewModel settingsViewViewModel
            )
        {
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
            LocationCommand = new RelayCommand(OpenLocationView, CanOpenLocationView);
            SettingsCommand = new RelayCommand(OpenSettingsView, CanOpenSettingsView);
            CloseCommand = new RelayCommand(CloseApplication, CanCloseApplication);

            RegisterCommand = new RelayCommand(Register, CanRegister);
            SignInCommand = new RelayCommand(SignIn, CanSignIn);
            SignOutCommand = new RelayCommand(SignOut, CanSignOut);

            this.homeViewViewModel = homeViewViewModel;
            this.registrationWindowViewModel = registrationWindowViewModel;
            this.signInWindowViewModel = signInWindowViewModel;
            this.settingsViewViewModel = settingsViewViewModel;

            this.userStorage = userStorage;
            this.localizationServise = localizationServise;
            this.settingsServise = settingsServise;

            var settings =  settingsServise.Load();
            localizationServise.SetCulture(settings.Cultures);

            //Разобраться, как сбросить активного пользователя командой при закрытии приложения
            userStorage.ResetActiveUser();
            SetAutorizationStatus();
        }

        private void SetAutorizationStatus()
        {
            var user = userStorage.GetAutorizedUser();

            if (user == null)
            {
                UserName = String.Empty;
                OutAccount();
                return;
            }
            UserName = "Имя: " + user.Login;
            InAccount();
        }

        private void SignOut(object obj)
        {
            userStorage.ResetUser();
            SetAutorizationStatus();
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
            var signInWindow = new SignInWindow(signInWindowViewModel);
            signInWindow.ShowDialog();
            SetAutorizationStatus();
        }

        private bool CanRegister(object arg)
        {
            return true;
        }

        private void Register(object obj)
        {
            var registrationWindow = new RegistrationWindow(registrationWindowViewModel);
            registrationWindow.ShowDialog();
            SetAutorizationStatus();
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
            SelectedContent = settingsViewViewModel;
        }

        private bool CanCloseApplication(object arg)
        {
            return true;
        }

        private void CloseApplication(object obj)
        {
            Application.Current.MainWindow.Close();
        }

        private void OutAccount()
        {
            RegisterButtonIsVisible = true;
            SignInButtonIsVisible = true;

            SignOutButtonIsVisible = false;
            UserNameLabelIsVisible = false;
        }

        private void InAccount()
        {
            RegisterButtonIsVisible = false;
            SignInButtonIsVisible = false;

            SignOutButtonIsVisible = true;
            UserNameLabelIsVisible = true;
        }
    }
}
