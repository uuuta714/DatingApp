namespace API.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository {get;}
    IMessageRepository MessageRepository {get;}
    ILikesRepository LikesRepository {get;}
    // This is where we can save the changes regardless of which repository
    Task<bool> Complete();
    // This will tell us if Entity Framework is tracking any changes to an entity
    // This is where we can check if there are any changes before committing to save to the database
    bool HasChanges();
}
