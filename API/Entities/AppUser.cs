namespace API.Entities;

public class AppUser
{
    // Access modifier should be public to use Enity Framework 
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
}
