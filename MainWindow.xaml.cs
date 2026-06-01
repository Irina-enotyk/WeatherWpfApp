using AutorizationWpfApp;
using System.Windows;
using System.Windows.Controls;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserStorage userStorage { get; } = new UserStorage();

        public MainWindow()
        {
            InitializeComponent();

            signOutButton.Click += SignOutButton_Click;
            Loaded += MainWindow_Loaded;

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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var signInUser = userStorage.GetSignInUser();
            if (signInUser != null)
            {
                userNameLabel.Visibility = Visibility.Visible;
                signOutButton.Visibility = Visibility.Visible;
                personRoomLabel.Visibility = Visibility.Visible;

                signInButton.Visibility = Visibility.Hidden;
                registrationButton.Visibility = Visibility.Hidden;
            }
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            userNameLabel.Visibility = Visibility.Hidden;
            signOutButton.Visibility = Visibility.Hidden;
            personRoomLabel.Visibility = Visibility.Hidden;

            signInButton.Visibility = Visibility.Visible;
            registrationButton.Visibility = Visibility.Visible;
        }
    }
}