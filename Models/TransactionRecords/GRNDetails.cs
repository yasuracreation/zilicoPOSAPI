using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Products;

namespace zilicoPOSAPI.Models.TransactionRecords
{
    [Table("GRNDetail")]
    public class GRNDetails
    {
        public int Id { get; set; }
        public int GRNId { get; set; }
        public int ProductId { get; set; }
        public int QuantityReceived { get; set; }

        // Navigation Properties
        // public GRN GRN { get; set; }
        // public Product Product { get; set; }
    }
}