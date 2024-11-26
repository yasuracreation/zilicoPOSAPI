using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Products;

namespace zilicoPOSAPI.Models.TransactionRecords
{
     [Table("GTNDetail")]
    public class GTNDetails
    {
         public int Id { get; set; }
        public int GTNId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation Properties
        // public GTN GTN { get; set; }
        // public Product Product { get; set; }
    }
}