using System.ComponentModel.DataAnnotations;

namespace zilicoPOSAPI.Dtos.MasterItem;

public class CreateProduct
{
    [Required]
    [MaxLength(100, ErrorMessage = "Name cannot be over 100 characters")]
    public string Name { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    [Required]
    public string Barcode { get; set; } = string.Empty;
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int StockQuantity { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsPrescriptionRequired { get; set; }

}