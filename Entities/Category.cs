using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class Category
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? ParentCategoryId { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
