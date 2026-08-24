
using Newtonsoft.Json;
using System.IO;

namespace WeatherWpfApp.Servises.Settings
{
    public class SettingsServise : ISettingsServise
    {
        public Settings Settings { get; }  = Load();

        private const string fileName = "Settings.json";

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Settings);
            File.WriteAllText(fileName, json);
        }

        private static Settings Load()
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
