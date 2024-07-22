using API.Entities;

namespace API.Interfaces;

// Interface is an abstraction of what the service is gonna do
// Without specifying how is going to do it
// No specific implementations inside interface

public interface ITokenService
{
    string CreateToken(AppUser user);
}