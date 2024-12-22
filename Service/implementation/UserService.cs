namespace user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Register(string username, string email, string password)
        {
            if (_userRepository.GetUserByName(username) != null || _userRepository.GetUserByEmail(email) != null)
            {
                throw new ArgumentException("User with this email or username already exists.");
            }
            var user = new User(username, email, password);
            _userRepository.AddUser(user);
            return user;
        }

        public User? Login(string username, string password)
        {
            var user = _userRepository.GetUserByName(username);
            if (user != null && user.IsPasswordCorrect(password))
            {
                return user;
            }
            return null;
        }

        public void DeleteUser(string username)
        {
            var user = GetUserByName(username) ?? throw new ArgumentException($"User with name '{username}' not found.");
            _userRepository.DeleteUser(user);
        }

        public List<User>? GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User? GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User? GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }
        public void UpdateUserBalance(User user)
        {
            var existingUser = GetUserByName(user.UserName);
            if (existingUser != null)
            {
                existingUser.UpdateBalance(user.GetBalance());
                _userRepository.UpdateUserBalance(user);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }
    }
}