
using Newtonsoft.Json;
using System.IO;

namespace WeatherWpfApp.Servises.Settings
{
    public class SettingsServise : ISettingsServise
    {

        //Эта запись равнозначна вызову метода Load() в конструкторе?
        public Settings Settings => Load();

        private const string fileName = "Settings.json";

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Settings);
            File.WriteAllText(fileName, json);
        }

        private Settings Load()
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
