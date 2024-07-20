namespace API.Entities;

public class AppUser
{
    // Access modifier should be public to use Enity Framework 
    public int Id { get; set; }
    public required string UserName { get; set; }
}
