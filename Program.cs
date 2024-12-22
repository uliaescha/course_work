using user;
using dbcontex;
using purchase;
using ui;
using goods;

class Program
{
    static void Main(string[] args)
    {
        var dbContext = new Dbcontex();

        var userRepository = new UserRepository(dbContext);
        var goodsRepository = new GoodsRepository(dbContext);
        var purchaseRepository = new PurchaseRepository(dbContext);

        var userService = new UserService(userRepository);
        var goodsService = new GoodsService(goodsRepository);
        var purchaseService = new PurchaseService(purchaseRepository);

        var register = new RegisterUser(userService);
        var login = new LoginUser(userService);

        MainMenuUI? mainMenu = null;

        mainMenu = new MainMenuUI(
            register,
            login,
            currentUser =>
            {
                var userMenu = new UserMenuUI(
                    currentUser,
                    new List<UI>
                    {
                        new ViewGoods(goodsService),
                        new PurchaseGoods(purchaseService, goodsService, userService, currentUser),
                        new AddBalance(userService, currentUser),
                        new ViewPurchaseHistory(purchaseService, currentUser),
                        new ShowUserInfo(userService, currentUser),
                        new DeleteUser(userService, () => mainMenu!.Execute())
                    });

                userMenu.Execute();
            });

        mainMenu.Execute();
    }
}
