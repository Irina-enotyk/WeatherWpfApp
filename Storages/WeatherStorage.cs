using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages
{
    public class WeatherStorage : IWeatherStorage
    {
        public List<DayForecastModel> GetAll()
        {
            var days = new List<DayForecastModel>();
            var random = new Random();

            for (int i = 0; i < 7; i++)
            {
                var weathers = Enum.GetValues(typeof(WeatherCodes));
                var winds = Enum.GetValues(typeof(WindDirection));

                var day = new DayForecastModel()
                {
                    Date = DateTime.Now.Date.AddDays(i - 3),
                    WeekDay = DateTime.Now.Date.AddDays(i - 3).Day.ToString(),
                    MaxTemperature = random.Next(23, 34),
                    MinTemperature = random.Next(12, 23),
                    Pressure = random.Next(745, 770),
                    WindSpeed = random.Next(8),
                    WindDirection = (WindDirection)winds.GetValue(random.Next(winds.Length)),
                    Weather = (WeatherCodes)weathers.GetValue(random.Next(weathers.Length)),
                    Location = "Saint-Peterburg"
                };
                days.Add(day);
            }
            return days;
        }
    }
}
