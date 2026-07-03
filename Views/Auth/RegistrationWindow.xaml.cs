using System.Windows;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public string Login
        {
            get
            {
                return loginTextBox.Text;
            }
        }
        public string Password
        {
            get
            {
                return passwordPasswordBox.Password;
            }
        }
        public string RepeatPassword
        {
            get
            {
                return repeatPasswordBox.Password;
            }
        }

        public RegistrationWindow()
        {
            InitializeComponent();
        }
    }
}
