namespace TourDe.Data;

public class AssignmentRepository: IAssignmentRepository
{
    private readonly IdentityContext _context;

    public AssignmentRepository(IdentityContext context)
    {
        _context = context;
    }
}