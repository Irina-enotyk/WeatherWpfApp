
using WeatherWpfApp.Servises.Localizations;
using WeatherWpfApp.Views.Settings;

namespace WeatherWpfApp.ViewModels
{
    public class SettingsViewViewModel : BaseViewModel
    {
        private readonly ILocalizationServise localizationServise;

        public SettingsViewViewModel(ILocalizationServise localizationServise)
        {
            this.localizationServise = localizationServise;
        }

        private Cultures culture;
        public Cultures Culture
        {
            get => culture;
            set
            {
                culture = value;
                localizationServise.SetCulture(culture);
                OnPropertyChanged();
            }
        }
    }
}
