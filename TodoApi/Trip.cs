namespace TodoApi
{
    public class Trip
    {
        public int Id { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        public int StationStartId { get; set; }

        public int BicycleId { get; set; }

        public int StationEndId { get; set; }

        public int Status { get; set; }
    }
}
