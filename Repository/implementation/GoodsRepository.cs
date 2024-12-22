using dbcontex;

namespace goods
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly Dbcontex _dbcontex;
        private const string GoodsFilePath = "JSON/goods.json";

        public GoodsRepository(Dbcontex dbcontex)
        {
            _dbcontex = dbcontex;
        }

        public void AddGood(Goods good)
        {
            _dbcontex.Goods.Add(good);
            _dbcontex.SaveToFile(_dbcontex.Goods, GoodsFilePath);
        }

        public void DeleteGood(Goods good)
        { 
            _dbcontex.Goods.Remove(good);
            _dbcontex.SaveToFile(_dbcontex.Goods, GoodsFilePath);
        }

        public Goods? GetByName(string name)
        {
            return _dbcontex.Goods.FirstOrDefault(g => g.GoodsName == name);
        }

        public List<Goods>? ReadAllGoods()
        {
            return _dbcontex.Goods;
        }
        public void UpdateGoodsQuantity(Goods good)
        {
            _dbcontex.SaveToFile(_dbcontex.Goods, GoodsFilePath);
        }

    }
}
