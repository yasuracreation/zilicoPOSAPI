using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace zilicoPOSAPI.Models.OrderManagement
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId {get; set;}
        [Required]
        public int CustomerId { get; set; }
        // public Customer Customer { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ShiftId { get; set; }

        // public Shift Shift { get; set; }

        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsReturnable { get; set; }
        // public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}