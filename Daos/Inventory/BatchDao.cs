namespace zilicoPOSAPI.Daos.Inventory;

public class BatchDao
{
    public int Id { get; set; }
    public string BatchNumber { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsActive { get; set; } 
}