namespace zilicoPOSAPI.Daos.Inventory;

public class InventoryItemDao
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SKU { get; set; }
    public int CategoryId { get; set; }
    public int BatchId { get; set; }
    public int? PurchaseOrderId { get; set; }
}