using dbcontex;
namespace purchase
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly Dbcontex _dbcontex;
        private const string PurchasesFilePath = "JSON/purchases.json";

        public PurchaseRepository(Dbcontex dbcontex)
        {
            _dbcontex = dbcontex;
        }

        public void AddPurchase(Purchase purchase)
        {
            _dbcontex.Purchases.Add(purchase);
            _dbcontex.SaveToFile(_dbcontex.Purchases, PurchasesFilePath);
        }

        public List<Purchase>? GetHistoryByUserName(string username)
        {
            return _dbcontex.Purchases
                .Where(p => p.User.UserName.Equals(username, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
