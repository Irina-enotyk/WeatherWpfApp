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
            try { ExistsLogin(loginTextBox.Text); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            if (repeatPasswordTextBox.Text == passwordTextBox.Text)
            {
                var user = new User(loginTextBox.Text, passwordTextBox.Text);
                user.IsSignIn = true;
                userStorage.Add(user);
                MessageBox.Show("Успешная регистрация!");
                Close();
                return;
            }
            MessageBox.Show("Пароли не совпадают!");
            repeatPasswordTextBox.Clear();
        }

        private void ExistsLogin(string login)
        {
            var registratedUsers = userStorage.GetAll();
            foreach(var user in registratedUsers)
            {
                if(user.Login == login)
                {
                    throw new Exception("Пользователь с таким логином уже зарегистрирован!");
                }
            }
        }
    }
}
