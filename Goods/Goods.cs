namespace goods 
{
    public class Goods 
    {
        public string GoodsName { get; }
        public int Quantity { get; set; }
        public decimal  Price { get; }

        public Goods(string goodsName, int quantity, decimal price)
        {
            GoodsName = goodsName;
            Quantity = quantity;
            Price = price;
        }

        public void ReduceQuantity(int quantity)
        {
            Quantity -= quantity; 
        }
    }
   
}