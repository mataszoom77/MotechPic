using System.Collections.Generic;

namespace MotechPicFront.Server.Models
{
    public class Admin
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Navigation Properties
        //public ICollection<SparePart> SpareParts { get; set; } = new List<SparePart>();
        //public ICollection<ProductRequest> ProductRequests { get; set; } = new List<ProductRequest>();
    }
}
