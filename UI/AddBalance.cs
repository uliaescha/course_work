using user;

namespace ui
{
    public class AddBalance : UI
    {
        private readonly IUserService _userService;
        private readonly User _currentUser;

        public AddBalance(IUserService userService, User currentUser)
        {
            _userService = userService;
            _currentUser = currentUser;
        }

        public void Execute()
        {
            Console.Write("Enter the amount to add: ");
            if (decimal.TryParse(Console.ReadLine(), out var amount))
            {
                try
                {
                    if (amount < 0)
                    {
                        throw new ArgumentException("The balance can`t be lower than 0");
                    }
                    _currentUser.AddtoBalance(amount);
                    _userService.UpdateUserBalance(_currentUser);
                    Console.WriteLine($"Balance updated. Current balance: {_currentUser.GetBalance()}");
                    Console.WriteLine("\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount.");
                Console.WriteLine("\n");
            }
        }

        public string ShowInfo()
        {
            return "Add balance to your account.";
        }
    }
}
