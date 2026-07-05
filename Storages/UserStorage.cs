using WeatherWpfApp.Models;

namespace WeatherWpfApp.Storages
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
            SetRememberUser(user, users);
            SetActiveUser(user, users);
            FileProvider.Save(users, fileName);
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

        public void SetRememberUser(User signInUser, List<User> users)
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

        public void SetActiveUser(User activeUser, List<User> users)
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
