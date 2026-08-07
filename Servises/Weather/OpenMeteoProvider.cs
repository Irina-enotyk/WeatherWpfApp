
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using WeatherWpfApp.Models;

namespace WeatherWpfApp.Servises.Weather
{
    public class OpenMeteoProvider
    {
        private readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://api.open-meteo.com/v1/forecast/")
        };

        public WeatherForecast GetWeather(float latitude, float longitude, ForecastMeasuresModel measures)
            {
                //Здпесь плохо пониаю, как рааботает этот url
                var url = new StringBuilder();
                url.Append("?latitude=" + latitude.ToString(CultureInfo.InvariantCulture));
                url.Append("&longitude=" + longitude.ToString(CultureInfo.InvariantCulture));
                url.Append("&temperature_unit=" + measures.TemperatureMeasure.ToString().ToLower());
                url.Append("&timezone=auto");
                url.Append("&past_days=2");
                url.Append("&daily=temperature_2m_max,temperature_2m_min,precipitation_sum,rain_sum,showers_sum,snowfall_sum,precipitation_hours,weathercode,sunrise,sunset,windspeed_10m_max,windgusts_10m_max,winddirection_10m_dominant");
                url.Append("&hourly=temperature_2m,relativehumidity_2m,apparent_temperature,surface_pressure,windspeed_10m,winddirection_10m,weathercode");

                DailyApiResponse response;

                try
                {
                    response = _httpClient.GetFromJsonAsync<DailyApiResponse>(url.ToString()).Result;
                }
                catch
                {
                    return null;
                }
                return ToWeatherForecastModel(response!, measures, latitude, longitude);
            }

        private WeatherForecast ToWeatherForecastModel(DailyApiResponse dailyApiResponse, ForecastMeasuresModel measures, float latitude, float longitude)
        {
            var weatherForecast = new WeatherForecast();

            weatherForecast.Location = new()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            weatherForecast.TemperatureMeasure = measures.TemperatureMeasure;

            int hoursCounter = 0;
            for(int i = 0; i < dailyApiResponse?.Daily?.Time?.Count; i++)
            {
                DayForecastModel day = new()
                {
                    Date = dailyApiResponse.Daily.Time[i],
                    Weather = (WeatherCodes)dailyApiResponse.Daily.Weathercode[i],
                    MaxTemperature = dailyApiResponse.Daily.Temperature_2m_max[i],
                    MinTemperature = dailyApiResponse.Daily.Temperature_2m_min[i],
                    WindSpeed = dailyApiResponse.Daily.Windspeed_10m_max[i],
                    //тут что-то не загружается, надо поправить
                    //WindDirection = (WindDirection)dailyApiResponse.Daily.Winddirection_10m_dominantion[i]
                };

                float pressure = 0;
                for (int j = hoursCounter; j < hoursCounter + 24; j++)
                {
                    HourlyForecastModel hour = new()
                    {
                        Time = dailyApiResponse.Hourly.Time[j],
                        Temperature = dailyApiResponse.Hourly.Temperature_2m[j],
                        ApparentTemperature = dailyApiResponse.Hourly.Apparent_temperature[j],
                        //RelativeHumidity = dailyApiResponse.Hourly.Relaitivehumidity[j],
                        SurfasePressure = dailyApiResponse.Hourly.Surface_pressure[j],
                        WindSpeed = dailyApiResponse.Hourly.Windspeed_10m[j],
                        //WindDirection = dailyApiResponse.Hourly.Winddirection_10m_dominantion[j],
                        Weather = (WeatherCodes)dailyApiResponse.Hourly.Weathercode[j]
                    };
                    day.HourlyForecast  .Add(hour);
                }

                //Почему так странно вычисляем? 
                //day.Pressure = pressure / 24;
                hoursCounter += 24;
                weatherForecast.DayForecasts.Add(day);
            }
            weatherForecast.StartDay = dailyApiResponse.Daily.Time.First();
            weatherForecast.EndDay = dailyApiResponse.Daily.Time.Last();

            return weatherForecast;
        }
    }
}
