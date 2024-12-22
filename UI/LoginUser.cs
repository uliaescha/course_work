using user;

namespace ui
{
    public class LoginUser : UI
    {
        private readonly IUserService _userService;
        private User? _loggedInUser;

        public LoginUser(IUserService userService)
        {
            _userService = userService;
        }

        public void Execute()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = ReadPassword();

            _loggedInUser = _userService.Login(name!, password!);

            if (_loggedInUser != null)
            {
                Console.WriteLine($"\nWelcome, {_loggedInUser.UserName}!");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\nInvalid name or password.");
                Console.WriteLine("\n");
            }
        }

        public User? GetLoggedInUser()
        {
            return _loggedInUser;
        }

        public string ShowInfo()
        {
            return "Login to the system.";
        }

        private string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*"); 
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}
