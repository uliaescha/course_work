namespace goods 
{
    public interface IGoodsRepository
    {
        List<Goods>? ReadAllGoods(); 
        Goods? GetByName(string name);
        void DeleteGood(Goods good); 
        void AddGood(Goods good);
        void UpdateGoodsQuantity(Goods good);
    }
}