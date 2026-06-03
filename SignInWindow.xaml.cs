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
            signInnButton.Click += SignInnButton_Click;
        }

        private void SignInnButton_Click(object sender, RoutedEventArgs e)
        {
            if(loginTextBox.Text == null || passwordTextBox.Text == null)
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
            
            if (currentUser.Password != passwordTextBox.Text)
            {
                MessageBox.Show("Неверный пароль");
                return;
            }

            if (rememberMeCheckBox.IsChecked == true)
            {
                userStorage.SwitchSignInUser(currentUser);
            }
            userStorage.SwitchActiveUser(currentUser);
            Close();
        }
    }
}
