using System.Globalization;
using WeatherWpfApp.Servises.Localizations;

namespace WeatherWpfApp.Models
{
    public class User
    {
        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }

        public CultureInfo CultureSetting { get; set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}