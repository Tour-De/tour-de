namespace TourDe.Data;

public class LocationRepository: ILocationRepository
{
    private readonly DatabaseContext _context;

    public LocationRepository(DatabaseContext context)
    {
        _context = context;
    }
}