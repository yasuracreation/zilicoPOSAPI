using System;
using System.Collections.Generic;

namespace zilicoPOSAPI.Entities;

public partial class ProductTag
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? TagName { get; set; }

    public virtual Product? Product { get; set; }
}
