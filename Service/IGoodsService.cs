namespace goods
{
    public interface IGoodsService
    {
        List<Goods>? ReadAllGoods();
        Goods? GetByName(string name);
        void DeleteGood(string name);
        Goods AddGood(string name, int quantity, decimal price);
        void UpdateGoodsQuantity(Goods good);
    }

}