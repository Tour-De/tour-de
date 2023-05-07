using Microsoft.EntityFrameworkCore;
using TourDe.Models;

namespace TourDe.Api.Data;

public class DatabaseContext: DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasIndex(p => p.Email).IsUnique();
        modelBuilder.Entity<Location>();
        modelBuilder.Entity<Assignment>();
    }
}