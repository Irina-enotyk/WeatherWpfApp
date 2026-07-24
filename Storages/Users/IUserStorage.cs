using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages.Users
{
    public interface IUserStorage
    {
        public List<User> GetAll();

        public void Add(User user);

        public User GetUserByLogin(string login);

        public User GetAutorizedUser();

        public void WhriteRememberUser(User signInUser, List<User> users);

        public void WhriteActiveUser(User signInUser, List<User> users);

        public void ResetUser();

        public void ResetActiveUser();
    }
}
