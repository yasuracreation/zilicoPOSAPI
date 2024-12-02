using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Product
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AlternativeItem> AlternativeItemAlternativeItemNavigations { get; set; } = new List<AlternativeItem>();

    public virtual ICollection<AlternativeItem> AlternativeItemItems { get; set; } = new List<AlternativeItem>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PlaceOrderDetail> PlaceOrderDetails { get; set; } = new List<PlaceOrderDetail>();

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
