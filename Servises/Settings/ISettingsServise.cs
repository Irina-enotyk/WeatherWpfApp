namespace WeatherWpfApp.Servises.Settings
{
    public interface ISettingsServise
    {
        void Save(Settings settings);

        Settings Load();
    }
}