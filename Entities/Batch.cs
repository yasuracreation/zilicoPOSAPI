using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Batch
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Grn> Grns { get; set; } = new List<Grn>();

    public virtual ICollection<Gtn> Gtns { get; set; } = new List<Gtn>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
