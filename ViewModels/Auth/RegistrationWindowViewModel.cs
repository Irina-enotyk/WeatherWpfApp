using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherWpfApp.Models;
using WeatherWpfApp.Storages.Users;

namespace WeatherWpfApp.ViewModels.Auth
{
    public class RegistrationWindowViewModel : BaseViewModel
    {
        public ICommand RegistrationCommand { get; }

        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private string repeatedPassword;
        public string RepeatedPassword
        {
            get => repeatedPassword;
            set
            {
                repeatedPassword = value;
                OnPropertyChanged();
            }
        }

        private readonly IUserStorage userStorage;

        public RegistrationWindowViewModel(IUserStorage userStorage)
        {
            RegistrationCommand = new RelayCommand(TryRegisterUser, CanTryRegisterUser);
            this.userStorage = userStorage;
        }

        private void TryRegisterUser(object obj)
        {
            var currentUser = userStorage.GetUserByLogin(Login);

            if (currentUser != null)
            {
                MessageBox.Show("Пользователь с таким логин уже зарегистрирован!");
                return;
            }

            try { InputValidator.CheckLogin(login); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try { InputValidator.CheckPassword(password); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (repeatedPassword != password)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            var user = new User(login, password);
            userStorage.Add(user);
            MessageBox.Show("Успешная регистрация!");

            var window = obj as Window;
            window.Close();
        }

        private bool CanTryRegisterUser(object arg)
        {
            return true;
        }
    }
}
