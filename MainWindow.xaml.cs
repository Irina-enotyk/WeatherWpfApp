using System.Windows;
using System.Timers;
using System.Windows.Media;
using LinearGradientBrush = System.Windows.Media.LinearGradientBrush;
using WeatherWpfApp.ViewModels;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer timer;

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
            SetInterfaceTheme();
        }

        private static void SetInterfaceTheme()
        {
            var hour = DateTime.Now.Hour;
            LinearGradientBrush gradient = new LinearGradientBrush { };
            SolidColorBrush solidBrush = new SolidColorBrush(Colors.White);

            if (hour <= 6 || hour >= 18)
            {
                gradient = new LinearGradientBrush
                {
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.SteelBlue, 1),
                        new GradientStop(Colors.MidnightBlue, 0),
                    }
                };
                solidBrush.Opacity = 0.25;
            }

            else
            {
                gradient = new LinearGradientBrush
                {
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.Coral, 0),
                        new GradientStop((Color)ColorConverter.ConvertFromString("#FFC371"), 1)
                    }
                };
            }

            Application.Current.Resources["MainWindowBackGround"] = gradient;
            Application.Current.Resources["LightBackground"] = solidBrush;
        }
    }
}