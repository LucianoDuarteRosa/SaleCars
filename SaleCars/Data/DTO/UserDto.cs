namespace SaleCars.Data.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool UserActive { get; set; }
    public int ProfileId { get; set; }
    public string ProfileName { get; set; }
}
