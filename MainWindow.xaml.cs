using System.Windows;
using System.Windows.Controls;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        private UserStorage userStorage { get; } = new UserStorage();

        public MainWindow()
        {
            InitializeComponent();
            SetSubscribes();
            LoadForecastData();
        }

        public void SetActiveUser()
        {
            if (user == null)
            {
                userNameLabel.Content = "Имя";
                return;
            }
            userNameLabel.Content = user.Login;
        }

        private void SetSubscribes()
        {
            registrationButton.Click += RegistrationButton_Click;
            signInButton.Click += SignInButtonButton_Click;
            signOutButton.Click += SignOutButton_Click;
            Loaded += MainWindow_Loaded;
            Activated += MainWindow_Activated;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            user = userStorage.GetSignInUser();
            SetActiveUser();
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            user = userStorage.GetActiveUser();
            SetActiveUser();
        }

        private void SignInButtonButton_Click(object sender, RoutedEventArgs e)
        {
            var signInWindow = new SignInWindow();
            signInWindow.ShowDialog();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            user = null;
            SetActiveUser();
        }

        private void WeatherDayButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var day = button.DataContext as DayForecastModel;
                Details_StackPanel.DataContext = day;
            }
        }

        private void LoadForecastData()
        {
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
                data, data2, data, data2, data, data2, data
            };
        }
    }
}