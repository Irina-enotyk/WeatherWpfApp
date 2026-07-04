using System.Windows;
using WeatherWpfApp.Storages;

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
        }
    }
}
