using TourDe.Api.Data;
using TourDe.Api.Test.Helpers;

namespace TourDe.Api.Test;

public class BaseDbContextFixture
{
    internal DatabaseContext _databaseContext;

    [SetUp]
    public void Init()
    {
        _databaseContext = new MockTourDeDb().CreateDbContext();
    }

    [TearDown]
    public void Cleanup()
    {
        _databaseContext.Dispose();
    }
}