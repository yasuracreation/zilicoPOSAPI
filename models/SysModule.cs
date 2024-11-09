using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models
{
    [Table("SysModule")]
    public class SysModule
    {
        public int Id { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public int RoleGroupId { get; set; }
        // Navigation properties
       public virtual RoleGroup RoleGroup { get; set; }
    }
}
