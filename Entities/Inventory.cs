using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Inventory
{
    public Guid Id { get; set; }

    public Guid? BatchId { get; set; }

    public Guid? WarehouseId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public virtual ICollection<ItemLocation> ItemLocations { get; set; } = new List<ItemLocation>();

    public virtual Warehouse? Warehouse { get; set; }
}
