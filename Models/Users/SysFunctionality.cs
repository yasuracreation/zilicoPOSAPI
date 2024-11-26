using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models.Users
{
    [Table("SysFunctionality")]
    public class SysFunctionality
    {
        public int Id { get; set; }
        public string FunctionName { get; set; } = string.Empty;

        // Navigation properties
          public int RoleGroupId { get; set; }

        // Navigation property for RoleGroup
        [ForeignKey("RoleGroupId")]
        public virtual RoleGroup RoleGroup { get; set; }
    }
}
