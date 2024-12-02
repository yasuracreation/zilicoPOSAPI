using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class SysModule
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<SysFunctionality> SysFunctionalities { get; set; } = new List<SysFunctionality>();
}
