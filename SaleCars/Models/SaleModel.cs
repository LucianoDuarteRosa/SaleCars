using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace SaleCars.Models;

[Table("sales")]
public class SaleModel
{
    [Key]
    public int SaleId { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime SaleDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal SaleValue { get; set; }

    [Required]
    public int SaleStatusId { get; set; }

    [Required]
    public int UserID { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    public int ClientId { get; set; }

    public SaleStatusModel SaleStatus { get; set; }
    public UserModel User { get; set; }
    public CarModel Car { get; set; }   
    public ClientModel Client { get; set; }

}
