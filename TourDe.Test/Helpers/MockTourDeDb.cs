using Microsoft.EntityFrameworkCore;
using TourDe.Api.Data;

namespace TourDe.Api.Test.Helpers;

public class MockTourDeDb : IDbContextFactory<DatabaseContext>
{
    /// <summary>
    /// Creates an in-memory database for use in unit testing.
    /// </summary>
    /// <returns></returns>
    public DatabaseContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
            .Options;

        return new DatabaseContext(options);
    }
}