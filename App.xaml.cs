using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WeatherWpfApp.Storages;
using WeatherWpfApp.ViewModels;

namespace WeatherWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                //Регистрация сервисов
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<HomeViewViewModel>();
                services.AddSingleton<IWeatherStorage, WeatherDataStorage>();
            }).Build();
        }

        protected async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            //Получение сервиса главного окна и его отображение
            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            //Почему нужно писать  using (_host) ?
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
            base.OnExit(e);
        }
    }
}
