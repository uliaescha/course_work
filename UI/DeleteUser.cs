using user;
using ui;

public class DeleteUser : UI
{
    private readonly IUserService _userService;
    private readonly Action _onUserDeleted;

    public DeleteUser(IUserService userService, Action onUserDeleted)
    {
        _userService = userService;
        _onUserDeleted = onUserDeleted;
    }

    public void Execute()
    {
        Console.Write("Enter your username to confirm deletion: ");
        var username = Console.ReadLine();

        try
        {
            _userService.DeleteUser(username!);
            Console.WriteLine("\nYour account has been successfully deleted.");
            Console.WriteLine("\n");
            _onUserDeleted(); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public string ShowInfo()
    {
        return "Delete your account.";
    }
}
