using System.Windows;
using System.Windows.Controls;
using WeatherWpfApp.Models;

namespace WeatherWpfApp.Views.Home
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }
        private void WeatherDayButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var day = button.DataContext as DayForecastModel;
                //Details_StackPanel.DataContext = day;
                //ForecastHours_ListBox.ItemsSource = day.HourlyForecast;
            }
        }

    }
}
