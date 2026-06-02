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

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            try { ValidateLogin(loginTextBox.Text); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try { ValidatePassword(passwordTextBox.Text); }
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

        private void ValidateLogin(string login)
        {
            var registratedUsers = userStorage.GetAll();
            foreach(var user in registratedUsers)
            {
                if(user.Login == login)
                {
                    throw new Exception("Пользователь с таким логином уже зарегистрирован!");
                }
            }

            foreach(var symbol in login)
            {
                if(symbol >='0' && symbol<= '9')
                {
                    throw new Exception("Логин не должен содержать цифры!");
                }
                if(!(symbol >='A' && symbol <= 'z'))
                {
                    throw new Exception("Для логина используйте только латинские буквы!");
                }
            }
        }

        private void ValidatePassword(string password)
        {
            var requaredSymbolCount = 5;

            if(password.Length < requaredSymbolCount)
            {
                throw new Exception("Пароль должен состоять минимум из 5 символов!");
            }

            var capitalLetterCount = 0;
            var lowercaseLetterCount = 0;
            var numberCount = 0;

            foreach(var symbol in password)
            {
                if(symbol >= 'A' && symbol <= 'Z')
                {
                    capitalLetterCount++;
                }
                else if(symbol >= 'a' && symbol <= 'z')
                {
                    lowercaseLetterCount++;
                }
                else if(symbol >= '0' && symbol <= '9')
                {
                    numberCount++;
                }
                else
                {
                    throw new Exception("Пароль должен содержать только латинские буквы и цифры!");
                } 
            }

            if (capitalLetterCount == 0 || lowercaseLetterCount == 0 || numberCount == 0)
            {
                throw new Exception("Пароль должен содержать минимум " +
                    "\n 1 Заглавную латинскую букву, " +
                    "\n 1 прописную латинскую букву, " +
                    "\n и 1 цифру!");
            }
        }
    }
}
