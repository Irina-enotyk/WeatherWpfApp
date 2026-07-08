using System.Windows.Controls;

namespace WeatherWpfApp.Views.Settings
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            
            //Culture_Combobox.ItemsSource = Enum.GetValues(typeof(Cultures)).Cast<Cultures>();
        }
    }
}
