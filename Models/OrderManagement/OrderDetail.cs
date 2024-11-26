using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace zilicoPOSAPI.Models.OrderManagement
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        // [ForeignKey("OrderId")]
        // public Order Order { get; set; }

        
    }
}