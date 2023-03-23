namespace Bank.Repository.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<BaseDeposit> Deposits { get; set; }
    }
}
