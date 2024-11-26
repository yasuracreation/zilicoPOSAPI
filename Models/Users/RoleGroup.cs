using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models.Users
{
    [Table("RoleGroup")]
    public class RoleGroup
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public virtual ICollection<SysFunctionality> SysFunctionalities { get; set; } = new List<SysFunctionality>();
        public virtual ICollection<SysModule> SysModules { get; set; } = new List<SysModule>();
    }
}
