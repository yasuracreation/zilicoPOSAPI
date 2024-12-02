using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class UserGroup
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
