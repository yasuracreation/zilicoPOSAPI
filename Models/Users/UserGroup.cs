using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models.Users
{
    [Table("UserGroup")]
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
        public virtual ICollection<RoleGroup> RoleGroups { get; set; } = new List<RoleGroup>();
    }
}
