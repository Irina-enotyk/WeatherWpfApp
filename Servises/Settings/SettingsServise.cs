
using Newtonsoft.Json;
using System.IO;

namespace WeatherWpfApp.Servises.Settings
{
    public class SettingsServise : ISettingsServise
    {
        private const string fileName = "Settings.json";

        public void Save(Settings settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(fileName, json);
        }

        public Settings Load()
        {
            if(!File.Exists(fileName))
            {
                return new Settings();
            }

            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<Settings>(json);
        }
    }
}
