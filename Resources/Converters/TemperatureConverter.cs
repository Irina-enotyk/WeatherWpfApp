
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WeatherWpfApp.Models;
using WeatherWpfApp.Servises;
using WeatherWpfApp.Servises.Settings;

namespace WeatherWpfApp.Resources.Converters
{
    public class TemperatureConverter : IValueConverter
    {
        private readonly ISettingsServise settingsService = ServiceLocator.ServiceProvider.GetService<ISettingsServise>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temperature = (float)value;

            var settings = settingsService.Load();
            var temperatureMeasure = settings.TemperatureMeasure;
            if (temperatureMeasure == TemperatureMeasure.Fahrenheit)
            {
                temperature += 32f;
            }
            var measure = Application.Current.Resources[temperatureMeasure.ToString()].ToString();
            return temperature + measure;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
