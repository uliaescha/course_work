using user;
using ui;

public class UserMenuUI : UI
{
    private readonly List<UI> _userInterfaces;
    private readonly User _currentUser;

    public UserMenuUI(User currentUser, List<UI> userInterfaces)
    {
        _currentUser = currentUser;
        _userInterfaces = userInterfaces;
    }

    public void Execute()
    {
        while (true)
        {
            Console.WriteLine($"User Menu - {_currentUser.UserName}:");

            for (int i = 0; i < _userInterfaces.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_userInterfaces[i].ShowInfo()}");
            }
            Console.WriteLine("0. Logout");

            Console.Write("Select an option: ");
            if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 0 || choice > _userInterfaces.Count)
            {
                Console.WriteLine("Invalid option. Try again.");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Logging out...");
                return;
            }

            _userInterfaces[choice - 1].Execute();
        }
    }

    public string ShowInfo()
    {
        return "User Menu";
    }
}
