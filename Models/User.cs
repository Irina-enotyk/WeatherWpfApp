using System.Globalization;

namespace WeatherWpfApp.Models
{
    public class User
    {
        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}