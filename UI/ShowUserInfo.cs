using user;

namespace ui
{
    public class ShowUserInfo : UI
    {
        private readonly IUserService _userService;
        private readonly User _currentUser;
        public ShowUserInfo(IUserService userService, User currentUser)
        {
            _userService = userService;
            _currentUser = currentUser;
        }

        public void Execute()
        {
            var user = _userService.GetUserByName(_currentUser.UserName!);
            if (user != null)
            {
                Console.WriteLine("\nUser Information:");
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Email: {user.UserEmail}");
                Console.WriteLine($"Balance: {user.GetBalance()}");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine($"User '{_currentUser.UserName}' not found.");
                Console.WriteLine("\n");
            }
        }

        public string ShowInfo()
        {
            return "View user information.";
        }
    }
}
