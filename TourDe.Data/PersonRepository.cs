using Microsoft.EntityFrameworkCore;
using TourDe.Core;
using TourDe.Core.Exceptions;
using TourDe.Models;

namespace TourDe.Data;

public class PersonRepository: IPersonRepository
{
    private readonly DatabaseContext _context;

    public PersonRepository(DatabaseContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task DeletePerson(string id)
    {
        _context.Persons.Remove(new ApplicationUser {Id = id});
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<ApplicationUser> UpdatePerson(ApplicationUser applicationUser)
    {
        var found = await _context.Persons.FindAsync(applicationUser.Id);
        if (found is null)
        {
            throw new NotFoundException(ExceptionMessages.PersonNotFound);
        }

        _context.Persons.Entry(applicationUser).CurrentValues.SetValues(applicationUser);
        await _context.SaveChangesAsync();
        return applicationUser;
    }

    /// <inheritdoc />
    public async Task<string> AddPerson(ApplicationUser applicationUser)
    {
        await _context.Persons.AddAsync(applicationUser);
        await _context.SaveChangesAsync();

        return applicationUser.Id;
    }

    /// <inheritdoc />
    public async Task<ApplicationUser?> GetPerson(string id)
    {
        return await _context.Persons.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<List<ApplicationUser>> GetAllPersons()
    {
        return await _context.Persons.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<ApplicationUser?> GetPersonByEmail(string email)
    {
        return await _context.Persons.FirstOrDefaultAsync(p => p.Email == email);
    }
}