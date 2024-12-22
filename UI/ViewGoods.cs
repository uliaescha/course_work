using goods;

namespace ui
{
    public class ViewGoods : UI
    {
        private readonly IGoodsService _goodsService;

        public ViewGoods(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        public void Execute()
        {
            var goods = _goodsService.ReadAllGoods();
            Console.WriteLine("\nAvailable Goods:");
            foreach (var good in goods!)
            {
                Console.WriteLine($"- {good.GoodsName}, Price: {good.Price}, Quantity: {good.Quantity}");
            }
            Console.WriteLine("\n");
        }

        public string ShowInfo()
        {
            return "View all available goods.";
        }
    }
}
