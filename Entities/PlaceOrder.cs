using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class PlaceOrder
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? SupplierId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<PlaceOrderDetail> PlaceOrderDetails { get; set; } = new List<PlaceOrderDetail>();

    public virtual Supplier? Supplier { get; set; }

    public virtual User? User { get; set; }
}
