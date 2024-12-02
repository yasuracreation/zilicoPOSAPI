using zilicoPOSAPI.Dtos.Inventory.Inventory;

namespace zilicoPOSAPI.Interfaces;

public interface IInventoryRepository : IGenericRepository<InventoryResponse>
{
    
    Task<InventoryResponse> GetInventory(Guid batchId, Guid userId);
    Task<InventoryResponse> GetInventory(Guid batchId, Guid userId, Guid productId);    
    Task<InventoryResponse> createInventory(Guid batchId, Guid userId, Guid productId);
}

// public interface IInventoryItemRepository : IGenericRepository<InventoryItem>
// {
//     
// }