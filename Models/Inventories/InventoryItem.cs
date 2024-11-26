using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Products;
using zilicoPOSAPI.Models.TransactionRecords;

namespace zilicoPOSAPI.Models.Inventories
{

    [Table("InventoryItem")]
  public class InventoryItem
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SKU { get; set; }
    public int CategoryId { get; set; }
    // public Category Category { get; set; }
     // Foreign key for Batch
    public int BatchId { get; set; }

    // Navigation property for Batch
    // public Batch Batch { get; set; }
    // public int? PurchaseOrderId { get; set; }
    // public PurchaseOrder PurchaseOrder { get; set; }
    // public bool IsPrescriptionRequired { get; set; } // Indicates if the item is prescription-only
    // public ICollection<InventoryItem> AlternativeItems { get; set; } // Tracks alternative drugs or items
    // public int InventoryId { get; set; }
    // public Inventory Inventory { get; set; }
  }
}