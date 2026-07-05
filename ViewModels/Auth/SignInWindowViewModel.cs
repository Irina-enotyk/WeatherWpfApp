
using System.Windows;
using System.Windows.Input;
using WeatherWpfApp.Storages;

namespace WeatherWpfApp.ViewModels.Auth
{
    public class SignInWindowViewModel : BaseViewModel
    {

        public ICommand SignInCommand { get; }

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

        private bool rememberMe;
        public bool RememberMe
        {
            get => rememberMe;
            set
            {
                rememberMe = value;
                OnPropertyChanged();
            }
        }

        private UserStorage userStorage;

        public SignInWindowViewModel()
        {
            SignInCommand = new RelayCommand(TrySignIn, CanTrySignIn);
            this.userStorage = new UserStorage();
        }

        private bool CanTrySignIn(object arg)
        {
            return true;
        }

        private void TrySignIn(object obj)
        {
            if (Login == null || Password == null)
            {
                MessageBox.Show("Заполните поля!");
                return;
            }

            if (Login == string.Empty || Password == string.Empty)
            {
                MessageBox.Show("Заполните поля!");
                return;
            }

            var currentUser = userStorage.GetUserByLogin(Login);
            if (currentUser == null)
            {
                MessageBox.Show("Пользователь с таким логин ещё не зарегистрирован!");
                return;
            }

            if (currentUser.Password != Password)
            {
                MessageBox.Show("Неверный пароль");
                return;
            }

            var users = userStorage.GetAll();
            if (RememberMe)
            {
                userStorage.SetRememberUser(currentUser, users);
            }
            else
            {
                userStorage.SetActiveUser(currentUser, users);
            }
            
            //Close();
        }
    }
}
