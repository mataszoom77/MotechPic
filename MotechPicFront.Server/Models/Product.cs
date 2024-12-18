﻿using System.Collections.Generic;

namespace MotechPicFront.Server.Models
{
    public class Product
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool SparePartsAvailable { get; set; }

        // Navigation Properties
        public ICollection<SparePart> SpareParts { get; set; } = new List<SparePart>();
        //public ICollection<ProductRequest> ProductRequests { get; set; } = new List<ProductRequest>();
    }
}
