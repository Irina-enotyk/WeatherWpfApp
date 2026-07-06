
using System.Globalization;
using System.Windows;
using WeatherWpfApp.Views.Settings;

namespace WeatherWpfApp.Servises.Localizations
{
    public class LocalizationServise : ILocalizationServise
    {
        private Dictionary<Cultures, ResourceDictionary> cultureDictionary = new Dictionary<Cultures, ResourceDictionary>() 
        {
            { Cultures.EN, new ResourceDictionary() {Source = new Uri("Resources/Localization/Language.en-US.xaml", UriKind.RelativeOrAbsolute) } },
            { Cultures.RU, new ResourceDictionary() {Source = new Uri("Resources/Localization/Language.ru-RU.xaml", UriKind.RelativeOrAbsolute) } },
        };

        public void SetCulture(Cultures culture)
        {
            Application.Current.Resources.MergedDictionaries.Add(cultureDictionary[culture]);
            CultureInfo.CurrentCulture = new CultureInfo(Application.Current.Resources["lang"].ToString());
        }
    }
}
