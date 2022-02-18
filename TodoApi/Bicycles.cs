

namespace TodoApi.Data
{
    public class Bicycles
    {
        public int Id { get; set; }

        public int Status { get; set; } 

        public string Description { get; set; } = string.Empty;

        public int StationId { get; set; } 

        public string LicensePlate { get; set; } = string.Empty;

    }
}
