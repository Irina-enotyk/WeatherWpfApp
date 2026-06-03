namespace WeatherWpfApp
{
    public class UserStorage
    {
        private const string fileName = "Users.json";

        public User GetSignInUser()
        {
            var users = GetAll();
            return users.FirstOrDefault(x => x.IsSignIn);
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
            SwitchSignInUser(user);
            FileProvider.Save(users, fileName);
        }

        public User GetUserByLogin(string login)
        {
            var users = GetAll();
            return users.FirstOrDefault(x => (x.Login == login));
        }

        public void SwitchSignInUser(User signInUser)
        {
            var users = GetAll();
            foreach (var user in users)
            {
                if (signInUser.Login == user.Login)
                {
                    user.IsSignIn = true;
                }
                else { user.IsSignIn = false; }
            }
            FileProvider.Save(users, fileName);
        }

        public void SwitchActiveUser(User signInUser)
        {
            var users = GetAll();
            foreach (var user in users)
            {
                if (signInUser.Login == user.Login)
                {
                    user.IsActive = true;
                }
                else { user.IsActive = false; }
            }
            FileProvider.Save(users, fileName);
        }

        private List<User> GetAll()
        {
            var users = FileProvider.Load<List<User>>(fileName) ?? new List<User>();
            return users;
        }
    }
}
