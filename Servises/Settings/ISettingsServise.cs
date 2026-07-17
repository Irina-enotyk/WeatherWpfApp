namespace WeatherWpfApp.Servises.Settings
{
    public interface ISettingsServise
    {
        public void Save(Settings settings);

        public Settings Load();
    }
}