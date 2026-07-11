using WeatherWpfApp.Servises.Localizations;

namespace WeatherWpfApp.ViewModels
{
    public partial class SettingsViewViewModel : BaseViewModel
    {
        private readonly ILocalizationServise localizationServise;

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

        private List<Temperatures> temperatures;

        // Не понимаю, почему не даёт назвать свойство Temperatures
        public List<Temperatures> Temperaturess
        {
            get => temperatures;
            set
            {
                if (temperatures == value) return;
                temperatures = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewViewModel(ILocalizationServise localizationServise)
        {
            this.localizationServise = localizationServise;

            Cultures = Enum.GetValues(typeof(Cultures)).Cast<Cultures>().ToList();
            Temperaturess = Enum.GetValues(typeof(Temperatures)).Cast<Temperatures>().ToList();
        }
    }
}
