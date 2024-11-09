using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace zilicoPOSAPI.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserType { get; set; }  // Indicates user role type (e.g., admin, customer)

        // Navigation property for UserProfile
        public virtual UserProfile UserProfile { get; set; }

        // Navigation property for Logins
        public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

        // Properties for relationships with UserGroup and RoleGroup
        public int? UserGroupId { get; set; }  // Nullable for optional relationships
        public virtual UserGroup? UserGroup { get; set; }

        public int? RoleGroupId { get; set; }  // Nullable for optional relationships
        public virtual RoleGroup? RoleGroup { get; set; }
    }
}
