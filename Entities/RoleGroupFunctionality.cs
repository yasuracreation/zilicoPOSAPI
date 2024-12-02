using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class RoleGroupFunctionality
{
    public Guid Id { get; set; }

    public Guid? RoleGroupId { get; set; }

    public Guid? FunctionalityId { get; set; }

    public virtual SysFunctionality? Functionality { get; set; }

    public virtual RoleGroup? RoleGroup { get; set; }
}
