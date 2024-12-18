using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SaleCars.Models;

[Table("users")]
public class UserModel : IdentityUser<int>
{
    [Key]
    public int UserID { get; set; }

    [NotMapped]
    public string Password { get; set; }

    [Required]
    public bool UserActive { get; set; }


    [Required]
    [ForeignKey("Profile")]
    public int ProfileId { get; set; }

    public ProfileModel Profile { get; set; }
}
