using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models.Users
{
    [Table("Login")]
    public class Login
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }  // Added foreign key for UserGroup
        public DateTime LoginTime { get; set; }
        public string IPAddress { get; set; } = string.Empty;

        // Navigation properties
        public virtual User User { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
