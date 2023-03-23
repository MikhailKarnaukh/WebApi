namespace Bank.Repository.Models
{
    public class Bank
    {
        public List<Customer> Customers { get; set; }
        public List<BaseDeposit> Deposits { get; set; }
    }
}
