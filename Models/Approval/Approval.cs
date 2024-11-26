using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using zilicoPOSAPI.Models.Inventories;
using zilicoPOSAPI.Models.Users;

namespace zilicoPOSAPI.Models.Approval
{
    [Table("Approvals")]
    public class Approval
    {
       public int Id { get; set; }
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }
    public string ApprovedBy { get; set; }
    public DateTime ApprovalDate { get; set; }
    
    public string Comments { get; set; }
    }
}