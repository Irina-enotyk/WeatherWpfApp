namespace WeatherWpfApp
{
    public class UserStorage
    {
        private const string fileName = "Users.json";

        public User GetSignInUser()
        {
            var users = FileProvider.Load<List<User>>(fileName) ?? new List<User>();
            return users.FirstOrDefault(x => x.IsSignIn);
        }

        public List<User> GetAll()
        {
            var users = FileProvider.Load<List<User>>(fileName) ?? new List<User>();
            return users;
        }

        public void Add(User user)
        {
            var users = FileProvider.Load<List<User>>(fileName) ?? new List<User>();
            users.Add(user);
            FileProvider.Save(users, fileName);
        }
    }
}
