using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages.Users
{
    public class UserStorage : IUserStorage
    {
        private const string fileName = "Users.json";

        public List<User> GetAll()
        {
            return FileProvider.Load<List<User>>(fileName) ?? new List<User>();
        }

        public void Add(User user)
        {
            var users = GetAll();
            users.Add(user);
            WhriteUser(user, users);
        }

        private void WhriteUser(User user, List<User> users)
        {
            WhriteRememberUser(user, users);
            WhriteActiveUser(user, users);
        }

        public User GetUserByLogin(string login)
        {
            var users = GetAll();
            return users.FirstOrDefault(x => (x?.Login == login));
        }

        public User GetAutorizedUser()
        {
            var users = GetAll();
            return users.FirstOrDefault(x => (x.IsActive || x.IsRemember));
        }

        public void WhriteRememberUser(User signInUser, List<User> users)
        {
            foreach (var user in users)
            {
                if (signInUser.Login == user.Login)
                {
                    user.IsRemember = true;
                }
                else { user.IsRemember = false; }
            }
            FileProvider.Save(users, fileName);
        }

        public void WhriteActiveUser(User activeUser, List<User> users)
        {
            foreach (var user in users)
            {
                if (activeUser.Login == user.Login)
                {
                    user.IsActive = true;
                }
                else { user.IsActive = false; }
            }
            FileProvider.Save(users, fileName);
        }

        public void ResetUser()
        {
            var users = GetAll();
            foreach (var user in users)
            {
                user.IsActive = false;
                user.IsRemember = false;
            }
            FileProvider.Save(users, fileName);
        }

        public void ResetActiveUser()
        {
            var users = GetAll();
            foreach (var user in users)
            {
                user.IsActive = false;
            }
            FileProvider.Save(users, fileName);
        }
    }
}
