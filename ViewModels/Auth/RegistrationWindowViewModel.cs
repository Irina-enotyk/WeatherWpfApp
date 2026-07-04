using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherWpfApp.Models;
using WeatherWpfApp.Storages;

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

        private UserStorage userStorage;

        public RegistrationWindowViewModel()
        {
            RegistrationCommand = new RelayCommand(TryRegisterUser, CanTryRegisterUser);

            userStorage = new UserStorage();
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
                //repeatPasswordBox.Clear();
                return;
            }

            var user = new User(login, password);
            userStorage.Add(user);
            MessageBox.Show("Успешная регистрация!");
            //Close();
        }

        private bool CanTryRegisterUser(object arg)
        {
            return true;
        }
    }
}
