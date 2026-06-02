namespace WeatherWpfApp
{
    public class User
    {
        public bool IsSignIn { get; set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}