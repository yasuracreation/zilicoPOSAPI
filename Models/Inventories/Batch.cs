using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Models.Inventories
{
    [Table("Batch")]
    public class Batch
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; } // Indicates if the batch is still valid (e.g., not expired or recalled)
        
        // public ICollection<Inventory> Inventories { get; set; }

         // Navigation property
        // public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
    }
}