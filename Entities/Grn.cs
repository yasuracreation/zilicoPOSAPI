using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Grn
{
    public Guid Id { get; set; }

    public Guid? SupplierId { get; set; }

    public Guid? BatchId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
