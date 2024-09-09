namespace API.Helpers;

// Parameters used for LikesController.cs
public class LikesParams : PaginationParams
{   
    public int UserId { get; set; }
    public required string Predicate { get; set; } = "liked";
}
