using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleCars.Models;

[Table("profiles")]
public class ProfileModel
{
    [Key]
    public int ProfileId { get; set; }

    [Required]
    [StringLength(20)]
    public string ProfileName { get; set; }


}
