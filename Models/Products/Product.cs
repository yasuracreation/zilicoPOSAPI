using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models.Products
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsPrescriptionRequired { get; set; }

        // Navigation Property
        // public Category Category { get; set; }
    }
}
