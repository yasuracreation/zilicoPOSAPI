using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class InventoryItem
{
    public Guid Id { get; set; }

    public Guid? InventoryId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual Product? Product { get; set; }
}
