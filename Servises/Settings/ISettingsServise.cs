namespace WeatherWpfApp.Servises.Settings
{
    public interface ISettingsServise
    {
        Settings Settings { get; }

        public void Save();
    }
}