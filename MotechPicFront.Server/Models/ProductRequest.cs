using Newtonsoft.Json;

namespace MotechPicFront.Server.Models
{
    public class ProductRequest
    {
        public int Id { get; set; }  // Primary Key
        public string Message { get; set; } = string.Empty;


        // Foreign Key and Navigation Property
        public int ProductId { get; set; }
        public Product? Product { get; set; } = null!;
        public int ClientID { get; set; }
        public Client? Client { get; set; } = null!;
    }
}
