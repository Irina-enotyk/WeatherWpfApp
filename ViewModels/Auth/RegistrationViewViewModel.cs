
using System.Windows;
using System.Windows.Input;
using WeatherWpfApp.Models;
using WeatherWpfApp.Storages;

namespace WeatherWpfApp.ViewModels.Auth
{
    public class RegistrationViewViewModel : BaseViewModel
    {
        public ICommand RegistrationCommand { get; }

        private string login;

        private string password;

        private string repeatedPassword;

        public RegistrationViewViewModel()
        {
            RegistrationCommand = new RelayCommand(RegisterUser, CanRegisterUser);
        }

        private bool CanRegisterUser(object arg)
        {
           return true;
        }

        private void RegisterUser(object obj)
        {
            var userStorage = new UserStorage();

            FieldsSetter();

            var currentUser = userStorage.GetUserByLogin(login);
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

        private void FieldsSetter()
        {
            var registrationWindow = new RegistrationWindow();

            login = registrationWindow.Login;
            password = registrationWindow.Password;
            repeatedPassword = registrationWindow.RepeatPassword;
        }
    }
}
