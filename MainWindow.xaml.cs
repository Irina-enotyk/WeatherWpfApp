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
        private bool IsSignOut = false;
        private UserStorage userStorage { get; } = new UserStorage();

        public MainWindow()
        {
            InitializeComponent();
            SetSubscribes();
            LoadForecastData();


            user = userStorage.GetRememberUser();
            var users = userStorage.GetAll();
            userStorage.SwitchActiveUser(user, users);
        }

        private void ShowUser()
        {
            if (user == null || IsSignOut)
            {
                userNameLabel.Content = "Имя";
                OutAccount();
                return;
            }
            userNameLabel.Content = "Имя: " + user.Login;
            InAccount();
        }

        private void SetSubscribes()
        {
            registrationButton.Click += RegistrationButton_Click;
            signInButton.Click += SignInButtonButton_Click;
            signOutButton.Click += SignOutButton_Click;
            Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            user = userStorage.GetActiveUser() ?? userStorage.GetRememberUser();
            ShowUser();
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
            IsSignOut = true;
            ShowUser();
        }

        private void OutAccount()
        {
            userNameLabel.Visibility = Visibility.Collapsed;
            signOutButton.Visibility = Visibility.Collapsed;

            registrationButton.Visibility = Visibility.Visible;
            signInButton.Visibility = Visibility.Visible;
        }
        private void InAccount()
        {
            userNameLabel.Visibility = Visibility.Visible;
            signOutButton.Visibility = Visibility.Visible;

            registrationButton.Visibility = Visibility.Collapsed;
            signInButton.Visibility = Visibility.Collapsed;
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
            WeatherDays_ListBox.ItemsSource = ForecastData.Load();
        }
    }
}