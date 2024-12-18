using System.Collections.Generic;

namespace MotechPicFront.Server.Models
{
    public class SparePart
    {
        public int Id { get; set; }  // Primary Key
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;

        // Foreign Key
        public int ProductId { get; set; }
        public Product? Product { get; set; } // Navigation Property to Product

        // Add the missing navigation property
        //public ICollection<SparePartRequest> SparePartRequests { get; set; } = new List<SparePartRequest>();
    }
}
