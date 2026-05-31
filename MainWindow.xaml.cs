using System.Windows;
using System.Windows.Controls;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var data = new DayForecastModel
            {
                Date = DateTime.Now,
                MaxTemperature = 20,
                MinTemperature = 10
            };
            var data2 = new DayForecastModel
            {
                Date = DateTime.Now,
                MaxTemperature = 25,
                MinTemperature = 14
            };

            WeatherDays_ListBox.ItemsSource = new List<DayForecastModel>
            {
                data, data2, data, data2
            };                                                                      
        }

        private void WeatherDayButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                var day = button.DataContext as DayForecastModel;
                Details_StackPanel.DataContext = day;
            }
        }
    }
}