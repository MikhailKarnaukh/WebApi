namespace Bank.Repository.Models
{
    public class BaseDeposit
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double Value { get; set; }
        public double Persent { get; set; }
        public double AddedValue { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
