using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class InventoryTransaction
{
    public Guid Id { get; set; }

    public Guid? InventoryItemId { get; set; }

    public string? TransactionType { get; set; }

    public DateTime? QuantityIntTransactionDate { get; set; }

    public virtual InventoryItem? InventoryItem { get; set; }
}
