using ui;
using user;

public class MainMenuUI : UI
{
    private readonly List<UI> _menuOptions;
    private readonly Action<User> _onLoginSuccess;

    public MainMenuUI(RegisterUser registerUI, LoginUser loginUI, Action<User> onLoginSuccess)
    {
        _menuOptions = new List<UI>
        {
            registerUI,
            loginUI
        };
        _onLoginSuccess = onLoginSuccess;
    }

    public void Execute()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            for (int i = 0; i < _menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuOptions[i].ShowInfo()}");
            }
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();
            if (!int.TryParse(input, out var choice) || choice < 0 || choice > _menuOptions.Count)
            {
                Console.WriteLine("Invalid option. Try again.");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Exiting program!");
                Environment.Exit(0);
            }

            _menuOptions[choice - 1].Execute();

            if (_menuOptions[choice - 1] is RegisterUser register)
            {
                var registeredUser = register.GetRegisteredUser();
                if (registeredUser != null)
                {
                    _onLoginSuccess(registeredUser); 
                    return; 
                }
            }

            if (_menuOptions[choice - 1] is LoginUser login)
            {
                var currentUser = login.GetLoggedInUser();
                if (currentUser != null)
                {
                    _onLoginSuccess(currentUser); 
                    return; 
                }
            }
        }
    }

    public string ShowInfo()
    {
        return "Main Menu";
    }
}
