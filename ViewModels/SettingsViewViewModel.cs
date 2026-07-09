
using WeatherWpfApp.Servises.Localizations;

namespace WeatherWpfApp.ViewModels
{
    public class SettingsViewViewModel : BaseViewModel
    {
        private readonly ILocalizationServise localizationServise;

        public SettingsViewViewModel(ILocalizationServise localizationServise)
        {
            this.localizationServise = localizationServise;

            // Не сразу получилось. Так нормально?
            Cultures = Enum.GetValues(typeof(Cultures)).Cast<Cultures>().ToList();
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

        private List<Cultures> cultures;
        public List<Cultures> Cultures
        {
            get => cultures;
            set
            {
                cultures = value;
                OnPropertyChanged();
            }
        }
    }
}
