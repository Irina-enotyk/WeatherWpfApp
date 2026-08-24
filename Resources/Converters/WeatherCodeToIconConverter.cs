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
                case WeatherCodes.MainlyClear:
                    resourceName = "clear_sky";
                    break;

                case WeatherCodes.PartlyCloudy:
                    resourceName = "partly_cloudy";
                    break;

                case WeatherCodes.Overcast:
                    resourceName = "overcast";
                    break;

                case WeatherCodes.Fog:
                    resourceName = "fog";
                    break;
                case WeatherCodes.DepositingRimeFog:
                    resourceName = "fog";
                    break;

                case WeatherCodes.LightDrizzle:
                    resourceName = "drizzle";
                    break;
                case WeatherCodes.ModerateDrizzle:
                    resourceName = "drizzle";
                    break;
                case WeatherCodes.IntensityDrizzle:
                    resourceName = "drizzle";
                    break;
                case WeatherCodes.LightFreezingDrizzle:
                    resourceName = "drizzle";
                    break;
                case WeatherCodes.IntensityFreezingDrizzle:
                    resourceName = "drizzle";
                    break;

                case WeatherCodes.SlightRain:
                    resourceName = "slight_rain";
                    break;
                case WeatherCodes.ModerateRain:
                    resourceName = "slight_rain";
                    break;
                case WeatherCodes.HeavyIntensityRain:
                    resourceName = "slight_rain";
                    break;

                case WeatherCodes.SlightRainShowers:
                    resourceName = "slight_rain";
                    break;
                case WeatherCodes.ModerateRainShowers:
                    resourceName = "slight_rain";
                    break;
                case WeatherCodes.ViolentRainShowers:
                    resourceName = "slight_rain";
                    break;

                case WeatherCodes.SlightSnowFall:
                    resourceName = "snowfall";
                    break;
                case WeatherCodes.ModerateSnowFall:
                    resourceName = "snowfall";
                    break;
                case WeatherCodes.HeavySnowFall:
                    resourceName = "snowfall";
                    break;
                case WeatherCodes.SnowGrains:
                    resourceName = "snowfall";
                    break;

                case WeatherCodes.Thunderstorm:
                    resourceName = "thunderstorm";
                    break;
                case WeatherCodes.SlightThunderstormHail:
                    resourceName = "thunderstorm";
                    break;
                case WeatherCodes.HeavyThunderstormHail:
                    resourceName = "thunderstorm";
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
