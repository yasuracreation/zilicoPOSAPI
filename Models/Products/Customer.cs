using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Models.Products
{
     [Table("Customer")]
    public class Customer
    {
         public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Navigation Property
        // public ICollection<Sale> Sales { get; set; }
    }
}