namespace SaleCars.Data.DTO;

public class RegisterDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool UserActive { get; set; }
    public int ProfileId { get; set; }
}
