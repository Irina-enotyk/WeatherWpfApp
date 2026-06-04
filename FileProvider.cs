using System.IO;
using System.Text.Json;

namespace WeatherWpfApp
{
    public static class FileProvider
    {
        public static void Save(Object data, string fileName)
        {
            string serializedData = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, serializedData);
        }

        public static T Load<T>(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return default;
            }
            var jsonString = File.ReadAllText(fileName);

            if(string.IsNullOrEmpty(jsonString))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}