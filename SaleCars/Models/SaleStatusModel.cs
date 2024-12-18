using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleCars.Models;

[Table("sale_status")]
public class SaleStatusModel
{
    [Key]
    public int SaleStatusId { get; set; }

    [Required]
    [StringLength(20)]
    public string SaleStatusName { get; set; }
}
