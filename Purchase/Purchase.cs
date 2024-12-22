using goods;
using user;

namespace purchase
{
    public class Purchase
    {
        private static int _currentIndex = 0; 

        public int IndexOfPurchase { get; } 
        public int Quantity { get; }
        public User User { get; }
        public Goods Good { get; }
        public decimal TotalPrice => Good.Price * Quantity;

        public Purchase(User user, Goods good, int quantity)
        {
            IndexOfPurchase = ++_currentIndex;
            User = user;
            Good = good;
            Quantity = quantity;
        }
    }
}
