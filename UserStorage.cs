namespace WeatherWpfApp
{
    public class UserStorage
    {
        private const string fileName = "Users.json";

        public User GetRememberUser()
        {
            var users = GetAll();
            return users.FirstOrDefault(x => x.IsRemember);
        }

        public User GetActiveUser()
        {
            var users = GetAll();
            return users.FirstOrDefault(x => x.IsActive);
        }

        public void Add(User user)
        {
            var users = GetAll();
            users.Add(user);
            SwitchSignInUser(user, users);
            SwitchActiveUser(user, users);
            FileProvider.Save(users, fileName);
        }

        public User GetUserByLogin(string login)
        {
            var users = GetAll();
            return users.FirstOrDefault(x => (x.Login == login));
        }

        public void SwitchSignInUser(User signInUser, List<User> users)
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

        public void SwitchActiveUser(User activeUser, List<User> users)
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

        public List<User> GetAll()
        {
            return FileProvider.Load<List<User>>(fileName) ?? new List<User>();
        }
    }
}
