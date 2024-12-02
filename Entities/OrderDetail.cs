using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class OrderDetail
{
    public Guid Id { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
