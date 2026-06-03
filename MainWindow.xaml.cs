using System.Windows;
using System.Windows.Controls;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User activeUser;
        private UserStorage userStorage { get; } = new UserStorage();

        public MainWindow()
        {
            InitializeComponent();
            SetSubscribes();
            LoadForecastData();
        }

        public void SetActiveUser(User user)
        {
            activeUser = user;
            userNameLabel.Content = activeUser.Login;
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
            var signInUser = userStorage.GetSignInUser();
            if (signInUser != null)
            {
                SetActiveUser(signInUser);
            }
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            var activeUser = userStorage.GetActiveUser();
            if (activeUser != null)
            {
                SetActiveUser(activeUser);
            }
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