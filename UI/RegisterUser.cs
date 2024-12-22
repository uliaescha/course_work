using user;

namespace ui
{
    public class RegisterUser : UI
    {
        private readonly IUserService _userService;
        private User? _registeredUser;

        public RegisterUser(IUserService userService)
        {
            _userService = userService;
        }

        public void Execute()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Enter your email: ");
            var email = Console.ReadLine();

            string password;
            while (true)
            {
                Console.Write("Enter your password: ");
                var firstPassword = ReadPassword();

                Console.Write("Confirm your password: ");
                var secondPassword = ReadPassword();

                if (firstPassword == secondPassword)
                {
                    password = firstPassword!;
                    break;
                }
                else
                {
                    Console.WriteLine("Passwords do not match. Please try again.");
                    Console.WriteLine();
                }
            }

            try
            {
                _registeredUser = _userService.Register(name!, email!, password!);
                Console.WriteLine("Registration successful!");
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("\n");
            }
        }

        public User? GetRegisteredUser()
        {
            return _registeredUser;
        }

        public string ShowInfo()
        {
            return "Register a new user.";
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
