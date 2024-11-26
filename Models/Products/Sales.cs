using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models.Products
{
    [Table("Sale")]
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;

        // Navigation Properties
        // public Customer Customer { get; set; }
        // public ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
