using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Login
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User? User { get; set; }
}
