using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class SalesPayment
{
    public Guid Id { get; set; }

    public Guid? SaleId { get; set; }

    public Guid? PaymentId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual Sale? Sale { get; set; }
}
