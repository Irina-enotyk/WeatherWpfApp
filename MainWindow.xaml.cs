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

            registrationButton.Click += RegistrationButton_Click;
            signInButton.Click += SignInButtonButton_Click;
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

        private void SignInButtonButton_Click(object sender, RoutedEventArgs e)
        {
            var signInWindow = new SignInWindow();
            signInWindow.ShowDialog();

            userNameLabel.Visibility = Visibility.Visible;
            signOutButton.Visibility = Visibility.Visible;
            personRoomLabel.Visibility = Visibility.Visible;

            //signInButton.Visibility = Visibility.Collapsed;
            //registrationButton.Visibility = Visibility.Collapsed;
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();

            userNameLabel.Visibility = Visibility.Visible;
            signOutButton.Visibility = Visibility.Visible;
            personRoomLabel.Visibility = Visibility.Visible;

            //signInButton.Visibility = Visibility.Collapsed;
            //registrationButton.Visibility = Visibility.Collapsed;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var signInUser = userStorage.GetSignInUser();
            if (signInUser != null)
            {
                userNameLabel.Visibility = Visibility.Visible;
                signOutButton.Visibility = Visibility.Visible;
                personRoomLabel.Visibility = Visibility.Visible;

                signInButton.Visibility = Visibility.Collapsed;
                registrationButton.Visibility = Visibility.Collapsed;

                userNameLabel.Content = signInUser.Login.ToString();
            }
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            userNameLabel.Visibility = Visibility.Collapsed;
            signOutButton.Visibility = Visibility.Collapsed;
            personRoomLabel.Visibility = Visibility.Collapsed;

            signInButton.Visibility = Visibility.Visible;
            registrationButton.Visibility = Visibility.Visible;
        }

        private void WeatherDayButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var day = button.DataContext as DayForecastModel;
                Details_StackPanel.DataContext = day;
            }
        }
    }
}