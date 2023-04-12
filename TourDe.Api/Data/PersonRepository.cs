using Microsoft.EntityFrameworkCore;
using TourDe.Models;

namespace TourDe.Api.Data;

public class PersonRepository: IPersonRepository
{
    private readonly DatabaseContext _context;

    public PersonRepository(DatabaseContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task DeletePerson(int id)
    {
        _context.Persons.Remove(new Person {Id = id});
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<Person?> UpdatePerson(Person person)
    {
        var found = await _context.Persons.FindAsync(person.Id);
        if (found is null)
        {
            return null;
        }

        _context.Persons.Entry(person).CurrentValues.SetValues(person);
        await _context.SaveChangesAsync();
        return person;
    }

    /// <inheritdoc />
    public async Task<int> AddPerson(Person person)
    {
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();

        return person.Id;
    }

    /// <inheritdoc />
    public async Task<Person?> GetPerson(int id)
    {
        return await _context.Persons.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<List<Person>> GetAllPersons()
    {
        return await _context.Persons.ToListAsync();
    }
}