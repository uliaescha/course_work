using purchase;
using user;
namespace ui
{
    public class ViewPurchaseHistory : UI
    {
        private readonly IPurchaseService _purchaseService;
        private readonly User _currentUser;

        public ViewPurchaseHistory(IPurchaseService purchaseService, User currentUser)
        {
            _purchaseService = purchaseService;
            _currentUser = currentUser;
        }

        public void Execute()
        {
            var history = _purchaseService.GetHistoryByUserName(_currentUser.UserName);
            if(history == null || history.Count == 0)
            {
                Console.WriteLine($"The {_currentUser.UserName} doesn`t has purchase History:");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\nPurchase History:");
                foreach (var purchase in history)
                {
                    Console.WriteLine($"- {purchase.Good.GoodsName}, quantity: {purchase.Quantity}, total: {purchase.TotalPrice} - id: {purchase.IndexOfPurchase}");
                }
                Console.WriteLine("\n");
            }

        }
        public string ShowInfo()
        {
            return "View your purchase history.";
        }
    }
}
