namespace zilicoPOSAPI.Dtos.Inventory.Inventory;

public class InventoryResponse
{
    public int Id { get; set; }

    public int BatchId { get; set; } // Foreign key to the batch
    // public Batch Batch { get; set; }

    public int LocationId { get; set; } // Foreign key to the drug location (e.g., cabinet or aisle)
    // public ItemLocation Location { get; set; }

    public int Quantity { get; set; }
    public DateTime LastRestocked { get; set; }
    public DateTime ExpiryDate { get; set; } // For tracking the expiration date for specific items or batches

    public bool IsActive { get; set; } // Indicates if the item is currently active in the inventory (e.g., not expired or recalled)
    public int SupplierId { get; set; }
}