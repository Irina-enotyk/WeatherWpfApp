using System.Windows;
using System.Timers;
using WeatherWpfApp.Models;
using WeatherWpfApp.Storages;
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

        private User user;

        private bool IsSignOut;
        private UserStorage userStorage { get; } 

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            SetSubscribes();

            DataContext = mainWindowViewModel;

            timer = new System.Timers.Timer();
            timer.Interval = 3600000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            userStorage = new UserStorage();
            IsSignOut = false;

            var users = userStorage.GetAll();
            user = userStorage.GetAutorizedUser();

            if(user != null)
            {
                userStorage.SwitchActiveUser(user, users);
            }
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            var hour = DateTime.Now.Hour;
            LinearGradientBrush gradient = new LinearGradientBrush { };
            SolidColorBrush solidBrush = new SolidColorBrush(Colors.White);

            if (hour <=  6 || hour >= 18)
            {
                gradient = new LinearGradientBrush
                {
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.SteelBlue, 1),
                        new GradientStop(Colors.MidnightBlue, 0),
                    }
                };
                solidBrush.Opacity =0.25;
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

        private void SetSubscribes()
        {
            registrationButton.Click += RegistrationButton_Click;
            signInButton.Click += SignInButton_Click;
            signOutButton.Click += SignOutButton_Click;
            Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            user = userStorage.GetAutorizedUser();
            ShowUser();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var signInWindow = new SignInWindow();
            signInWindow.ShowDialog();

            IsSignOut = false;
            ShowUser();
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
    }
}