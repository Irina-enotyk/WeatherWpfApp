using System.Windows;
using WeatherWpfApp.Storages;
using WeatherWpfApp.ViewModels.Auth;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for SignInnWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow(SignInWindowViewModel signInWindowViewModel)
        {
            InitializeComponent();
            DataContext = signInWindowViewModel;
        }
    }
}
