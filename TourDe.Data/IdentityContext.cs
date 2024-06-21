using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TourDe.Core;
using TourDe.Models;

namespace TourDe.Data;

public class IdentityContext: IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser> Persons { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // identity entities
        modelBuilder.Entity<ApplicationUser>().ToTable(TableNames.ApplicationUsers);
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable(TableNames.UserClaims);
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable(TableNames.UserLogins);
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable(TableNames.UserTokens);
        modelBuilder.Entity<IdentityRole>().ToTable(TableNames.Roles).HasData(
            new IdentityRole(IdentityRoles.User){NormalizedName = IdentityRoles.User.ToUpper()},
            new IdentityRole(IdentityRoles.Admin){NormalizedName = IdentityRoles.Admin.ToUpper()}
        );
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable(TableNames.RoleClaims);
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable(TableNames.UserRoles);
    }
}