using Microsoft.EntityFrameworkCore;
using TourDe.Data;

namespace TourDe.Api.Test.Helpers;

public class MockTourDeDb : IDbContextFactory<TourDeContext>
{
    public TourDeContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<TourDeContext>()
            .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
            .Options;

        return new TourDeContext(options);
    }
}