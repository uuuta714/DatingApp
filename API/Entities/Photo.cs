using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set;}
    public required string Url { get; set;}
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }

    // Navigation properties

    // To set the required one to many relationship between AppUser and Photo
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}