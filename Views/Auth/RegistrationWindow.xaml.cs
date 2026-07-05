using System.Windows;
using WeatherWpfApp.ViewModels.Auth;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(RegistrationWindowViewModel registrationWindowViewModel)
        {
            InitializeComponent();
            DataContext = registrationWindowViewModel;
        }
    }
}
