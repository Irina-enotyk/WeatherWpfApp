using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WeatherWpfApp.Models;

namespace WeatherWpfApp.Resources.Converters
{
    class WindDirectionToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string resourceName = null;

            switch ((WindDirection)value)
            {
                case WindDirection.North:
                    resourceName = "wind_array_top";
                    break;
                case WindDirection.South:
                    resourceName = "wind_array_buttom";
                    break;
                case WindDirection.West:
                    resourceName = "wind_array_left";
                    break;
                case WindDirection.East:
                    resourceName = "wind_array_right";
                    break;
            }

            if(resourceName ==  null)
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
