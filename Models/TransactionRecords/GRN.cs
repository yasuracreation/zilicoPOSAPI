using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Users;

namespace zilicoPOSAPI.Models.TransactionRecords
{
    [Table("GRN")]
    public class GRN
    {
        public int Id { get; set; }
        public string GRNNumber { get; set; } = string.Empty;
        public DateTime ReceiptDate { get; set; }
        public string Status { get; set; } = "Pending"; // e.g., Pending, Received, Rejected
        public int ReceivedByUserId { get; set; }
        public int ApprovedByUserId { get; set; } // Nullable if not yet approved
        public int SupplierId { get; set; }
        // [ForeignKey("SupplierId")]
        // public Supplier Supplier { get; set; }
        public int? PurchaseOrderId { get; set; }
        // [ForeignKey("PurchaseOrderId")]
        // public PurchaseOrder PurchaseOrder { get; set; }
        // Navigation Property
        // public ICollection<GRNDetails> GRNDetails { get; set; }
    }
}