namespace TodoApi
{
    public class Payment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Type { get; set; }

        public int Money { get; set; }

        public int TripId { get; set; }

        public int TransactionId { get; set; }
        
        public string PaymentCode { get; set; }
    }
}
