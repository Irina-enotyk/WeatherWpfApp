namespace WeatherWpfApp
{
    public class UserStorage
    {
        private const string fileName = "Users.json";

        private List<User> users;

        public UserStorage ()
        {
            users = FileProvider.Load<List<User>>(fileName) ?? new List<User>();
        }

        public User GetSignInUser()
        {
            return users.FirstOrDefault(x => x.IsSignIn);
        }

        public User GetActiveUser()
        {
            return users.FirstOrDefault(x => x.IsActive);
        }

        public void Add(User user)
        {
            users.Add(user);
            SwitchSignInUser(user);
            FileProvider.Save(users, fileName);
        }

        public User GetUserByLogin(string login)
        {
            return users.FirstOrDefault(x => (x.Login == login));
        }

        public void SwitchSignInUser(User signInUser)
        {
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

        public void SwitchActiveUser(User activeUser)
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
    }
}
