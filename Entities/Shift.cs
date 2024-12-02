using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Shift
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual User? User { get; set; }
}
