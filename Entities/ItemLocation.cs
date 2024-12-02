using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class ItemLocation
{
    public Guid Id { get; set; }

    public Guid? InventoryId { get; set; }

    public string? Location { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Inventory? Inventory { get; set; }
}
