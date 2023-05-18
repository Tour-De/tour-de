using TourDe.Models;

namespace TourDe.Api.Data;

public interface IPersonRepository
{
    /// <summary>
    /// Deletes the <see cref="Person"/> from the database.
    /// </summary>
    /// <param name="id">The ID key for the record.</param>
    /// <returns></returns>
    public Task DeletePerson(int id);

    /// <summary>
    /// Updates the <see cref="Person"/>'s properties in the database.
    /// </summary>
    /// <param name="person">The person with updated properties.</param>
    /// <returns></returns>
    public Task<Person?> UpdatePerson(Person person);

    /// <summary>
    /// Adds a new <see cref="Person"/> record to the database.
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    public Task<int> AddPerson(Person person);

    /// <summary>
    /// Fetches a single <see cref="Person"/> record.
    /// </summary>
    /// <param name="id">The ID key of the record to fetch.</param>
    /// <returns></returns>
    public Task<Person?> GetPerson(int id);

    /// <summary>
    /// Gets all <see cref="Person"/> records from the database.
    /// </summary>
    /// <returns>A <see cref="List{T}"/> of <see cref="Person"/>s.</returns>
    public Task<List<Person>> GetAllPersons();

    /// <summary>
    /// Gets the person with the given email address.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Task<Person> GetPersonByEmail(string email);
}