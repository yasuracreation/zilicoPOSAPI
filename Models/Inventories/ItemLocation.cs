using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Models.Inventories
{
    [Table("ItemLocation")]
    public class ItemLocation
    {
       public int Id { get; set; }
    public string LocationName { get; set; }
    public string Description { get; set; } // Detailed location information (e.g., "Cabinet A, Shelf 3")
    
    // public ICollection<Inventory> Inventories { get; set; }
    }
}