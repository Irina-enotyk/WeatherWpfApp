using System.Windows;
using System.Windows.Controls;

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
            ScrollToLeft_Button.Click += ScrollToLeft_Button_Click;
            ScrollToRight_Button.Click += ScrollToRight_Button_Click;
        }

        private void ScrollToRight_Button_Click(object sender, RoutedEventArgs e)
        {
            WeatherDays_ScrollViewer.LineRight();
        }

        private void ScrollToLeft_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WeatherDays_ScrollViewer.LineLeft();
        }
    }
}
