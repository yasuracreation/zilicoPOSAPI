using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Inventories;

namespace zilicoPOSAPI.Models.TransactionRecords
{
    [Table("PurchaseOrderDetail")]
    public class PurchaseOrderDetail
    {
        [Key]
        public int PurchaseOrderDetailId { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }
        // [ForeignKey("PurchaseOrderId")]
        // public PurchaseOrder PurchaseOrder { get; set; }

        [Required]
        public int InventoryItemId { get; set; }
        // [ForeignKey("InventoryItemId")]
        // public InventoryItem InventoryItem { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}