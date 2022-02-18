namespace TodoApi
{
    public class Deposit
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; } = String.Empty;

        public int UserId { get; set; }

        public int TransactionId { get; set; }
    }
}
