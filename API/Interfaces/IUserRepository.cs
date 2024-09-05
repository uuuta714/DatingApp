using API.DTOs;
using API.Entities;
using API.Helpers;
using CloudinaryDotNet.Actions;

namespace API.Interfaces;
public interface IUserRepository
{
    void Update(AppUser user);

    // End the method name with "Async" for the method returning a task
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    Task<MemberDto?> GetMemberAsync(string username);
}
