using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Models.TransactionRecords
{
    [Table("PurchaseOrder")]
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Required]
        public int SupplierId { get; set; }
        // [ForeignKey("SupplierId")]
        // public Supplier Supplier { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime? ExpectedDeliveryDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; } = string.Empty;

        // public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}