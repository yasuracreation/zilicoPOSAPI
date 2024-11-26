using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Users;

namespace zilicoPOSAPI.Models.TransactionRecords
{
    [Table("GTN")]
    public class GTN
    {
        public int Id { get; set; }
        public string GTNNumber { get; set; } = string.Empty;
        public DateTime TransferDate { get; set; }
        public string Status { get; set; } = "Pending"; // e.g., Pending, Approved, Rejected
        public int CreatedByUserId { get; set; }
        public int ApprovedByUserId { get; set; } // Nullable if not yet approved
        public int SupplierId { get; set; }
        // [ForeignKey("SupplierId")]
        // public Supplier Supplier { get; set; }

        // Navigation Property
        // public ICollection<GTNDetails> GTNDetails { get; set; }
    }
}