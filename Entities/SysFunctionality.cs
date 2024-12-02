using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class SysFunctionality
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? ModuleId { get; set; }

    public virtual SysModule? Module { get; set; }

    public virtual ICollection<RoleGroupFunctionality> RoleGroupFunctionalities { get; set; } = new List<RoleGroupFunctionality>();
}
