using System.Windows;
using System.Windows.Input;

namespace AutorizationWpfApp
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

        private void PasswordTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                e.Handled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var message = string.Empty;

            if (repeatPasswordTextBox.Text != passwordTextBox.Text)
            {

                message = "Пароли не совпадают!";
            }
            else
            {
                var user = new User("", "");
                user.IsSignIn = true;
                userStorage.Add(user);
                message = "Успешная регистрация!";
            }

            MessageBox.Show(message);
            Close();
        }

        private void LoginTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                e.Handled = true;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
