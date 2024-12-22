// using user;
// using goods;
// namespace purchase
// {
//     public class PurchaseService : IPurchaseService
//     {
//         private readonly IPurchaseRepository _purchaseRepository;

//         public PurchaseService(IPurchaseRepository purchaseRepository)
//         {
//             _purchaseRepository = purchaseRepository;
//         }
//         public Purchase AddPurchase(User user, Goods good, int quantity)
//         {
//             var purchase = new Purchase(user, good, quantity);
//             good.ReduceQuantity(quantity);
//             user.ReduceBalance(purchase.TotalPrice);
//             _purchaseRepository.AddPurchase(purchase);
//             return purchase;
//         }

//         public List<Purchase>? GetHistoryByUserName(string username)
//         {
//             return _purchaseRepository.GetHistoryByUserName(username);
//         }
//     }
// }

using user;
using goods;

namespace purchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public Purchase AddPurchase(User user, Goods good, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity of purchase must be greater than zero.");
            }

            if (good.Quantity < quantity)
            {
                throw new InvalidOperationException($"Not enough {good.GoodsName} in stock. Available: {good.Quantity}, Requested: {quantity}.");
            }

            good.ReduceQuantity(quantity);

            if (user.GetBalance() < good.Price * quantity)
            {
                throw new InvalidOperationException("Insufficient balance to complete the purchase.");
            }
            
            user.ReduceBalance(good.Price * quantity);

            var purchase = new Purchase(user, good, quantity);

            _purchaseRepository.AddPurchase(purchase);

            return purchase;
        }

        public List<Purchase>? GetHistoryByUserName(string username)
        {
            return _purchaseRepository.GetHistoryByUserName(username);
        }
    }
}
