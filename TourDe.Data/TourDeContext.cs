using Microsoft.EntityFrameworkCore;
using TourDe.Models;

namespace TourDe.Data;

public class TourDeContext: DbContext
{
    public TourDeContext(DbContextOptions<TourDeContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>();
    }
}