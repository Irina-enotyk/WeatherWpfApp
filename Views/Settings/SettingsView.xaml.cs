using System.Windows.Controls;
using WeatherWpfApp.Servises.Localizations;
using WeatherWpfApp.ViewModels;

namespace WeatherWpfApp.Views.Settings
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView(SettingsViewViewModel settingsViewViewModel)
        {
            InitializeComponent();
            DataContext = settingsViewViewModel;

            Culture_Combobox.ItemsSource = Enum.GetValues(typeof(Cultures)).Cast<Cultures>();
        }
    }
}
