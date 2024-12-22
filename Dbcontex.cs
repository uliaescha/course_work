using goods;
using purchase;
using user;
using Newtonsoft.Json;

namespace dbcontex 
{
    public class Dbcontex
    {
        public List<User> Users { get; set; }
        public List<Goods> Goods { get; set; }
        public List<Purchase> Purchases { get; set; }

        private const string UsersFilePath = "JSON/users.json";
        private const string GoodsFilePath = "JSON/goods.json";
        private const string PurchasesFilePath = "JSON/purchases.json";

        public Dbcontex()
        {
            Users = LoadFromFile<User>(UsersFilePath);
            Goods = LoadFromFile<Goods>(GoodsFilePath);
            Purchases = LoadFromFile<Purchase>(PurchasesFilePath);
        }

        private List<T> LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public void SaveToFile<T>(List<T> data, string filePath)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

}
