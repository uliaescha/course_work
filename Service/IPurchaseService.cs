using user;
using goods;
namespace purchase
{
    public interface IPurchaseService
    {
        Purchase AddPurchase(User user, Goods good, int quantity);
        List<Purchase>? GetHistoryByUserName(string username);
    }

}