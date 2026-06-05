using System.Windows;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for SignInnWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        private UserStorage userStorage = new UserStorage();

        public SignInWindow()
        {
            InitializeComponent();
            signInButton.Click += SignInButton_Click;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == string.Empty || passwordPasswordBox.Password == string.Empty)
            {
                MessageBox.Show("Заполните поля!");
                return;
            }

            var currentUser = userStorage.GetUserByLogin(loginTextBox.Text);
            if (currentUser == null)
            {
                MessageBox.Show("Пользователь с таким логин ещё не зарегистрирован!");
                return;
            }
            
            if (currentUser.Password != passwordPasswordBox.Password)
            {
                MessageBox.Show("Неверный пароль");
                return;
            }

            var users = userStorage.GetAll();
            if (rememberMeCheckBox.IsChecked == true)
            {
                userStorage.SwitchRememberUser(currentUser, users);
            }
            userStorage.SwitchActiveUser(currentUser, users);
            Close();
        }
    }
}
