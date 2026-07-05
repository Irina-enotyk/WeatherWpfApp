using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages
{
    public interface IUserStorage
    {
        public List<User> GetAll();

        public void Add(User user);

        public User GetUserByLogin(string login);

        public User GetAutorizedUser();

        public void SetRememberUser(User signInUser, List<User> users);

        public void SetActiveUser(User signInUser, List<User> users);

        public void ResetUser();

        public void ResetActiveUser();
    }
}
