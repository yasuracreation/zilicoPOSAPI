using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Supplier
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? ContactInfo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Grn> Grns { get; set; } = new List<Grn>();

    public virtual ICollection<PlaceOrder> PlaceOrders { get; set; } = new List<PlaceOrder>();
}
