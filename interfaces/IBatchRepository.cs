using zilicoPOSAPI.Dtos.Inventory.Batch;

namespace zilicoPOSAPI.Interfaces;

public interface IBatchRepository : IGenericRepository<BatchResponse>
{
  
    Task<BatchResponse> GetBatchAsync(Guid batchId, Guid userId);   
    Task<BatchResponse> DeleteBatch(Guid batchId, Guid userId);

}