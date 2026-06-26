using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages
{
    public static class WeatherDataStorage
    {
        public static List<DayForecastModel> Load()
        {
            var days = new List<DayForecastModel>();

            for(int i = 0; i < 7; i++)
            {
                //Как понять, что нужно обратиться к WeatherCodes через typeof?
                var weathers = Enum.GetValues(typeof(WeatherCodes));
                var random = new Random();

                var day = new DayForecastModel()
                {
                    Date = DateTime.Now.Date.AddDays(i - 3),
                    WeekDay = DateTime.Now.Date.AddDays(i - 3).Day.ToString(),
                    MaxTemperature = random.Next(23, 34),
                    MinTemperature = random.Next(12, 23),
                    Pressure = random.Next(745, 770),
                    WindSpeed = random.Next(8),
                    WindDirection = (WindDirection)random.Next(9),
                    Weather = (WeatherCodes)weathers.GetValue(random.Next(weathers.Length)),
                    Location = "Saint-Peterburg"
                };
                days.Add(day);
            }
            return days;
        }
    }
}
