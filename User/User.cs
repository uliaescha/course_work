using Newtonsoft.Json;

namespace user
{
    public class User
    {
        public string UserName { get; }
        public string UserEmail { get; }
        [JsonProperty] private readonly string Password;
        [JsonProperty] private decimal Balance;

        public User(string userName, string userEmail, string password, decimal balance = 0)
        {
            UserName = userName;
            UserEmail = userEmail;
            Password = password;
            Balance = balance;
        }

        public void AddtoBalance(decimal amount)
        {
            Balance += amount;
        }
        public void ReduceBalance(decimal amount)
        {
            Balance -= amount;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
        public void UpdateBalance(decimal newBalance)
        {
            Balance = newBalance;
        }

        public bool IsPasswordCorrect(string password)
        {
            return Password == password;
        }
    }
}
