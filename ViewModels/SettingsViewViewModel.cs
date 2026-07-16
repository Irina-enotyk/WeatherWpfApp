using WeatherWpfApp.Models;
using WeatherWpfApp.Servises.Localizations;
using WeatherWpfApp.Servises.Settings;

namespace WeatherWpfApp.ViewModels
{
    public class SettingsViewViewModel : BaseViewModel
    {
        private readonly ILocalizationServise localizationServise;
        private readonly Settings settings;
        private readonly ISettingsServise settingsServise;
        private Cultures culture;
        public Cultures Culture
        {
            get => culture;
            set
            {
                if (culture == value) return;
                culture = value;
                localizationServise.SetCulture(culture);
                OnPropertyChanged();

                settings.Cultures = culture;
                settingsServise?.Save(settings);
            }
        }

        private List<Cultures> cultures;
        public List<Cultures> Cultures
        {
            get => cultures;
            set
            {
                if (cultures == value) return;
                cultures = value;
                OnPropertyChanged();
            }
        }

        private TemperatureMeasure temperatureMeasure;
        public TemperatureMeasure TemperatureMeasure
        {
            get => temperatureMeasure;
            set
            {
                if(temperatureMeasure == value) return;
                temperatureMeasure = value;
                OnPropertyChanged();

                settings.TemperatureMeasure = temperatureMeasure;
                settingsServise?.Save(settings);
            }
        }

        private List<TemperatureMeasure> temperatureMeasures;

        // Не понимаю, почему не даёт назвать свойство Temperatures
        public List<TemperatureMeasure> TemperatureMeasures
        {
            get => temperatureMeasures;
            set
            {
                if (temperatureMeasures == value) return;
                temperatureMeasures = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewViewModel(ILocalizationServise localizationServise, ISettingsServise settingsServise)
        {
            this.localizationServise = localizationServise;
            this.settingsServise = settingsServise;
            this.settings = new Settings();

            Cultures = Enum.GetValues(typeof(Cultures)).Cast<Cultures>().ToList();
            TemperatureMeasures = Enum.GetValues(typeof(TemperatureMeasure)).Cast<TemperatureMeasure>().ToList();
        }
    }
}
