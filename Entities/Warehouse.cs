using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Warehouse
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Gtn> GtnSourceWarehouses { get; set; } = new List<Gtn>();

    public virtual ICollection<Gtn> GtnTargetWarehouses { get; set; } = new List<Gtn>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
