using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class PlaceOrderDetail
{
    public Guid Id { get; set; }

    public Guid? PlaceOrderId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual PlaceOrder? PlaceOrder { get; set; }

    public virtual Product? Product { get; set; }
}
