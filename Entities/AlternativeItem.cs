using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class AlternativeItem
{
    public Guid Id { get; set; }

    public Guid? ItemId { get; set; }

    public Guid? AlternativeItemId { get; set; }

    public string? Reason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product? AlternativeItemNavigation { get; set; }

    public virtual Product? Item { get; set; }
}
