using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Models.Products
{
   
    [Table("SaleDetail")]
    public class SaleDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double PriceAtSale { get; set; }

        // Navigation Properties
        // public Sale Sale { get; set; }
        // public Product Product { get; set; }
    }
}