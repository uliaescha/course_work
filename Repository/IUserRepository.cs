namespace user 
{
    public interface IUserRepository
    {
        void AddUser(User user); 
        List<User>? GetAllUsers(); 
        User? GetUserByEmail(string email);
        User? GetUserByName(string name);
        void DeleteUser(User user);
        void UpdateUserBalance(User user);
    }
}