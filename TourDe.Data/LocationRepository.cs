namespace TourDe.Data;

public class LocationRepository: ILocationRepository
{
    private readonly IdentityContext _context;

    public LocationRepository(IdentityContext context)
    {
        _context = context;
    }
}