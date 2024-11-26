using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Inventories;
using zilicoPOSAPI.Models.Users;

namespace zilicoPOSAPI.Models.Audit
{
     [Table("Audits")]
     public class Audit
     {   
          public int AuditId { get; set; }
          public string EntityName { get; set; } // e.g., "Order", "InventoryItem"
          public string Action { get; set; } // e.g., "Created", "Updated", "Deleted"
          public DateTime Timestamp { get; set; }
          public string Details { get; set; } // Optional JSON or description of changes
     }
}