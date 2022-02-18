namespace TodoApi
{
    public class BicycleType
    {
        public int Id { get; set; }

        public string Type { get; set; } = String.Empty;

        public int BicycleId { get; set; }

        public DateTime DateAdded { get; set; }

        public int Color { get; set;}
    }
}
