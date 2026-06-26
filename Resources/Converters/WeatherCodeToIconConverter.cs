using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WeatherWpfApp.Models;

namespace WeatherWpfApp.Resources.Converters
{
    public class WeatherCodeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string resourceName = null;

            switch ((WeatherCodes)value)
            {
                case WeatherCodes.ClearSky:
                    resourceName = "clear_sky";
                    break;

                case WeatherCodes.PartlyCloudy:
                    resourceName = "partly_cloudy";
                    break;
                case WeatherCodes.Overcast:
                    resourceName = "overcast";
                    break;
                case WeatherCodes.Drizzle:
                    resourceName = "drizzle";
                    break;
                case WeatherCodes.Fog:
                    resourceName = "fog";
                    break;
                case WeatherCodes.SlightRain:
                    resourceName = "slight_rain";
                    break;
                case WeatherCodes.Snowfall:
                    resourceName = "snowfall";
                    break;
                case WeatherCodes.Thunderstorm:
                    resourceName = "thunderstorm";
                    break;
                case WeatherCodes.Windy:
                    resourceName = "windy";
                    break;
            }
            if(resourceName == null)
            {
                return null;
            }

            return Application.Current.Resources[resourceName] as ControlTemplate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
