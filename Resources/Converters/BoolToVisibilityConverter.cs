
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WeatherWpfApp.Resources.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        private Visibility trueVisibility;
        private Visibility falseVisibility;

        public BoolToVisibilityConverter()
        {
            trueVisibility = Visibility.Visible;
            falseVisibility = Visibility.Collapsed;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (bool)value;
            return result ? trueVisibility : falseVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
