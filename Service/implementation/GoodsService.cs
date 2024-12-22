namespace goods 
{
    public class GoodsService : IGoodsService 
    {
        private readonly IGoodsRepository _goodsRepository;

        public GoodsService (IGoodsRepository goodsRepository) 
        {
            _goodsRepository = goodsRepository;
        }

        public Goods AddGood(string name, int quantity, decimal price)
        {
            if(name == null)
            {
                throw new ArgumentException("Name can`t be null");
            }
            if(quantity < 0) 
            {
                throw new ArgumentException("Quantity can`t be lower than 0");
            }
            if (price < 0)
            {
                throw new ArgumentException("Price can`t be lower than 0");
            }
            var good = new Goods(name, quantity, price);
            _goodsRepository.AddGood(good);
            return good;
        }

        public void DeleteGood(string name)
        {
            var good = GetByName(name) ?? throw new ArgumentException($"Good with name '{name}' not found.");
            _goodsRepository.DeleteGood(good);
        }

        public Goods? GetByName(string name)
        {
            return _goodsRepository.GetByName(name);
        }

        public List<Goods>? ReadAllGoods()
        {
            return _goodsRepository.ReadAllGoods();
        }
        public void UpdateGoodsQuantity(Goods good)
        {
            var existingGood = _goodsRepository.GetByName(good.GoodsName);
            if (existingGood != null)
            {
                existingGood.Quantity = good.Quantity;
                _goodsRepository.UpdateGoodsQuantity(existingGood);
            }
            else
            {
                throw new ArgumentException("Good not found.");
            }
        }

    }
}