using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleCars.Models;

[Table("supplier")]
public class SupplierModel
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    [StringLength(60)]
    public string SupplierName { get; set; }

    [Required]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Invalid CPF format. Use ###.###.###-##.")]
    public string SupplierCpf { get; set; }


    [Required]
    public string SupplierPhone { get; set; }

    [Required]
    [StringLength(255)]
    public string SupplierAdress { get; set; }

    [StringLength(20)]
    public string SupplierPixType { get; set; }

    [StringLength(255)]
    public string SupplierPixKey { get; set; }

    [StringLength(255)]
    public string SupplierNote { get; set; }

    [Required]
    public bool SupplierActive { get; set; }
}
