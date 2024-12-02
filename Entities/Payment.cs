using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Payment
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<OrderPayment> OrderPayments { get; set; } = new List<OrderPayment>();

    public virtual ICollection<SalesPayment> SalesPayments { get; set; } = new List<SalesPayment>();

    public virtual User? User { get; set; }
}
