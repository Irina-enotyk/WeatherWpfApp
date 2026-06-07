using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherWpfApp
{
    public static class ForecastData
    {
        public static List<DayForecastModel> Load()
        {
            var day1 = new DayForecastModel()
            {
                Date = DateTime.Now.Date,
                WeekDay = "Sunday",
                MaxTemperature = 25,
                MinTemperature = 14,
                Pressure = 1,
                WindSpeed = 2,
                WindDirection = WindDirection.North,
                Weather = WeatherCodes.ClearSky,
                Location = "Saint-Peterburg"
            };

            var days = new List<DayForecastModel>()
            {
                day1, day1, day1, day1, day1, day1, day1
            };

            return days;
        }
    }
}
