using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace SaleCars.Models;

[Table("cars")]
public class CarModel
{
    [Key]
    public int CarId { get; set; }

    [Required]
    [StringLength(100)]
    public string CarName { get; set; }

    [Required]
    [StringLength(30)]
    public string CarMark { get; set; }

    [Required]
    [Range(1900, 2200, ErrorMessage = "The year must be between 1900 and 2100.")]
    public int CarYear { get; set; }

    [Required]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "The value must be exactly 7 characters long.")]
    public string CarPlate { get; set; }

    public string CarCodeFipe { get; set; }
    public double CarTableFipe { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal CarValue { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal CarSaleValue { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime CarDateRegister { get; set; }

    [Required]
    public bool CarActive { get; set; }

    [Required]
    public bool CarIsSale { get; set; }

    [Required]
    public int SupplierId { get; set; }
    public SupplierModel Supplier { get; set; }
}
