namespace TodoApi
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; } = string.Empty;

        public int WalletId { get; set; }

        public int DepositId { get; set; }

    }
}
