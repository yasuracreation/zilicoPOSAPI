using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Gtn
{
    public Guid Id { get; set; }

    public Guid? SourceWarehouseId { get; set; }

    public Guid? TargetWarehouseId { get; set; }

    public Guid? BatchId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual Warehouse? SourceWarehouse { get; set; }

    public virtual Warehouse? TargetWarehouse { get; set; }
}
