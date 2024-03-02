namespace API.Entities;

public class AppUser
{
    //Properties has to be public to use Entity Framework
    public int Id { get; set; }
    public string UserName {get; set;}
}
