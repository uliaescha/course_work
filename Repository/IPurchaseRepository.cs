namespace purchase
{
    public interface IPurchaseRepository
    {
        void AddPurchase(Purchase purchase); 
        List<Purchase>? GetHistoryByUserName(string username); 
    }

}