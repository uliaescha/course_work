using goods;
using user;
using purchase;

namespace ui
{
    public class PurchaseGoods : UI
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IGoodsService _goodsService;
        private readonly IUserService _userService;
        private readonly User _currentUser;

        public PurchaseGoods(IPurchaseService purchaseService, IGoodsService goodsService, IUserService userService, User currentUser)
        {
            _purchaseService = purchaseService;
            _goodsService = goodsService;
            _userService = userService; 
            _currentUser = currentUser;
        }

        public void Execute()
        {
            Console.Write("Enter the name of the good to purchase: ");
            var goodsName = Console.ReadLine();

            var good = _goodsService.GetByName(goodsName!);

            if (good == null)
            {
                Console.WriteLine("Good not found. Please check the name and try again.");
                Console.WriteLine("\n");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out var quantity))
            {
                Console.WriteLine("Invalid quantity.");
                Console.WriteLine("\n");
                return;
            }

            try
            {
                var purchase = _purchaseService.AddPurchase(_currentUser, good, quantity);
                _userService.UpdateUserBalance(_currentUser);
                _goodsService.UpdateGoodsQuantity(good);
                Console.WriteLine($"Purchase successful! You bought {quantity}x {good.GoodsName} for {purchase.TotalPrice}");
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("\n");
            }
        }
        public string ShowInfo()
        {
            return "Purchase goods from the store.";
        }
    }
}
