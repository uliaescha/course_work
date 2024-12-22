using dbcontex;
namespace user
{
    public class UserRepository : IUserRepository
    {
        private readonly Dbcontex _dbcontex;
        private const string UsersFilePath = "JSON/users.json";

        public UserRepository(Dbcontex dbcontex)
        {
            _dbcontex = dbcontex;
        }

        public void AddUser(User user)
        {
            _dbcontex.Users.Add(user);
            _dbcontex.SaveToFile(_dbcontex.Users, UsersFilePath);
        }

        public void DeleteUser(User user)
        {
            _dbcontex.Users.Remove(user);
            _dbcontex.SaveToFile(_dbcontex.Users, UsersFilePath);
        }

        public List<User>? GetAllUsers()
        {
            return _dbcontex.Users;
        }

        public User? GetUserByEmail(string email)
        {
            return _dbcontex.Users.FirstOrDefault(u => u.UserEmail == email);
        }

        public User? GetUserByName(string name)
        {
            return _dbcontex.Users.FirstOrDefault(u => u.UserName == name);
        }

        public void UpdateUserBalance(User user)
        {
            _dbcontex.SaveToFile(_dbcontex.Users, UsersFilePath);
        }
    }
}
