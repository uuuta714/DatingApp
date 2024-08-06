﻿using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    // Name of a table in the database
    public DbSet<AppUser> Users { get; set; }
    // No need to create DbSet for Photo class
    // as we don't need to query specific photos by photo id.
    // Photos property in the AppUser plays as a navigation property
}
