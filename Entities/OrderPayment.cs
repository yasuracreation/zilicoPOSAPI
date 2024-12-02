using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class OrderPayment
{
    public Guid Id { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? PaymentId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Payment? Payment { get; set; }
}
