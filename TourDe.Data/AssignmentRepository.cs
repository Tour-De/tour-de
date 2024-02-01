namespace TourDe.Data;

public class AssignmentRepository: IAssignmentRepository
{
    private readonly DatabaseContext _context;

    public AssignmentRepository(DatabaseContext context)
    {
        _context = context;
    }
}