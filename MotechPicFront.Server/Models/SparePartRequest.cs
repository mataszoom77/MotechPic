using Newtonsoft.Json;

namespace MotechPicFront.Server.Models
{
    public class SparePartRequest
    {
        public int Id { get; set; }  // Primary Key
        public string Message { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;

        // Foreign Key and Navigation Property
        
        public int SparePartId { get; set; }
        public SparePart? SparePart { get; set; } = null!;

        public int ClientId { get; set; }
        public Client? Client { get; set; } = null!;
    }
}
