using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Models.Inventories
{
    [Table("InventoryTransaction")]
    public class InventoryTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; } // e.g., GRN, GTN
        public int BatchId { get; set; }
        public Batch Batch { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ApprovedBy { get; set; }
    }
}