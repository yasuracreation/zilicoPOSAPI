using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models.Products
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation Property
        // public ICollection<Product> Products { get; set; }
    }
}
