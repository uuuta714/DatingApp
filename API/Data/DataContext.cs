using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    // Name of a table in the database
    public DbSet<AppUser> Users { get; set; }
}
