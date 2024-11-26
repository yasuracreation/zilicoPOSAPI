using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace zilicoPOSAPI.Models.Users
{
  
    [Table("Shift")]
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        // [ForeignKey("User")]
        public int UserId { get; set; }
        // public User User { get; set; }
        // public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}