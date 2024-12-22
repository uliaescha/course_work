namespace user
{
    public interface IUserService
    {
        User Register(string username, string email, string password);
        List<User>? GetAllUsers();
        User? Login(string username, string password);
        User? GetUserByEmail(string email);
        User? GetUserByName(string name);
        void DeleteUser(string username);
        void UpdateUserBalance(User user);
    }
}