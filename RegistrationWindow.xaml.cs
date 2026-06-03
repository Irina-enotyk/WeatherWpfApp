using System.Windows;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private UserStorage userStorage { get; } = new UserStorage();

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = userStorage.GetUserByLogin(loginTextBox.Text);
            if (currentUser != null)
            {
                MessageBox.Show("Пользователь с таким логин уже зарегистрирован!");
                return;
            }

            try { InputValidator.CheckLogin(loginTextBox.Text); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try { InputValidator.CheckPassword(passwordTextBox.Text); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (repeatPasswordTextBox.Text != passwordTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                repeatPasswordTextBox.Clear();
                return;
            }

            var user = new User(loginTextBox.Text, passwordTextBox.Text);
            user.IsSignIn = true;
            userStorage.Add(user);

            MessageBox.Show("Успешная регистрация!");
            Close();
        }
    }
}
