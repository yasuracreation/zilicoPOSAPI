using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class RoleGroup
{
    public Guid Id { get; set; }

    public string? UserGroupId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<RoleGroupFunctionality> RoleGroupFunctionalities { get; set; } = new List<RoleGroupFunctionality>();
}
