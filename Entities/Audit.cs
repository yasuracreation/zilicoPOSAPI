using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Audit
{
    public Guid Id { get; set; }

    public string? EntityName { get; set; }

    public string? Action { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
