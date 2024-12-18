using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleCars.Models;

[Table("clients")]
public class ClientModel
{
    [Key]
    public int ClientId { get; set; }

    [Required]
    [StringLength(60)]
    public string ClientName { get; set; }

    [Required]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Invalid CPF format. Use ###.###.###-##.")]
    public string ClientCpf { get; set; }

    [Required]
    public string ClientPhone { get; set; }

    [Required]
    [StringLength(255)]
    public string ClientAdress { get; set; }

    [StringLength(20)]
    public string ClientPixType { get; set; }

    [StringLength(255)]
    public string ClientPixKey { get; set; }

    [StringLength(255)]
    public string ClientNote { get; set; }

    [Required]
    public bool ClientActive { get; set; }
}
