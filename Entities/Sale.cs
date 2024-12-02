using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Sale
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime? SaleDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User? Customer { get; set; }

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();

    public virtual ICollection<SalesPayment> SalesPayments { get; set; } = new List<SalesPayment>();
}
