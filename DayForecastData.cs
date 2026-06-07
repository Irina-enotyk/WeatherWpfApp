using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherWpfApp
{
    public static class DayForecastData
    {
        public static List<DayForecastModel> Load()
        {
            var day4 = new DayForecastModel()
            {
                Date = DateTime.Now.Date,
                WeekDay = DateTime.Now.Day.ToString(),
                MaxTemperature = 25,
                MinTemperature = 14,
                Pressure = 766,
                WindSpeed = 2,
                WindDirection = WindDirection.North,
                Weather = WeatherCodes.HeavyRain,
                Location = "Saint-Peterburg"
            };
            var day3 = new DayForecastModel()
            {
                Date = DateTime.Now.Date.AddDays(-1),
                WeekDay = DateTime.Now.Day.ToString(),
                MaxTemperature = 28,
                MinTemperature = 17,
                Pressure = 765,
                WindSpeed = 0,
                WindDirection = WindDirection.West,
                Weather = WeatherCodes.ClearSky,
                Location = "Saint-Peterburg"
            };
            var day2 = new DayForecastModel()
            {
                Date = DateTime.Now.Date.AddDays(-2),
                WeekDay = DateTime.Now.Day.ToString(),
                MaxTemperature = 22,
                MinTemperature = 11,
                Pressure = 760,
                WindSpeed = 1,
                WindDirection = WindDirection.NorthEast,
                Weather = WeatherCodes.Snowfall,
                Location = "Saint-Peterburg"
            };
            var day1 = new DayForecastModel()
            {
                Date = DateTime.Now.Date.AddDays(-3),
                WeekDay = DateTime.Now.Day.ToString(),
                MaxTemperature = 26,
                MinTemperature = 12,
                Pressure = 764,
                WindSpeed = 2,
                WindDirection = WindDirection.North,
                Weather = WeatherCodes.Windy,
                Location = "Saint-Peterburg"
            };
            var day5 = new DayForecastModel()
            {
                Date = DateTime.Now.Date.AddDays(1),
                WeekDay = DateTime.Now.Day.ToString(),
                MaxTemperature = 24,
                MinTemperature = 13,
                Pressure = 765,
                WindSpeed = 2,
                WindDirection = WindDirection.North,
                Weather = WeatherCodes.Thunderstorm,
                Location = "Saint-Peterburg"
            };
            var day6 = new DayForecastModel()
            {
                Date = DateTime.Now.Date.AddDays(2),
                WeekDay = DateTime.Now.Day.ToString(),
                MaxTemperature = 31,
                MinTemperature = 19,
                Pressure = 766,
                WindSpeed = 0,
                WindDirection = WindDirection.East,
                Weather = WeatherCodes.Fog,
                Location = "Saint-Peterburg"
            };
            var day7 = new DayForecastModel()
            {
                Date = DateTime.Now.Date.AddDays(3),
                WeekDay = DateTime.Now.Day.ToString(),
                MaxTemperature = 23,
                MinTemperature = 12,
                Pressure = 762,
                WindSpeed = 1,
                WindDirection = WindDirection.North,
                Weather = WeatherCodes.SlightRain,
                Location = "Saint-Peterburg"
            };

            var days = new List<DayForecastModel>()
            {
                day1, day2, day3, day4, day5, day6, day7
            };

            return days;
        }
    }
}
