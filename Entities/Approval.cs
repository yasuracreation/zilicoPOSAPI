using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Approval
{
    public Guid Id { get; set; }

    public string? EntityName { get; set; }

    public Guid? EntityId { get; set; }

    public Guid? UserId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
