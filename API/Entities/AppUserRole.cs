using Microsoft.AspNetCore.Identity;

namespace API.Entities;

// This class act as an joint table between AppUser and AppRole
public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; } = null!;
    public AppRole Role { get; set; } = null!; 
}
