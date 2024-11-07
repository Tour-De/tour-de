using TourDe.Models;

namespace TourDe.Data;

public interface IPersonRepository
{
    /// <summary>
    /// Deletes the <see cref="ApplicationUser"/> from the database.
    /// </summary>
    /// <param name="id">The ID key for the record.</param>
    /// <returns></returns>
    public Task DeletePerson(string id);

    /// <summary>
    /// Updates the <see cref="ApplicationUser"/>'s properties in the database.
    /// </summary>
    /// <param name="applicationUser">The applicationUser with updated properties.</param>
    /// <returns></returns>
    public Task<ApplicationUser> UpdatePerson(ApplicationUser applicationUser);

    /// <summary>
    /// Adds a new <see cref="ApplicationUser"/> record to the database.
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    public Task<string> AddPerson(ApplicationUser? person);

    /// <summary>
    /// Fetches a single <see cref="ApplicationUser"/> record.
    /// </summary>
    /// <param name="id">The ID key of the record to fetch.</param>
    /// <returns></returns>
    public Task<ApplicationUser?> GetPerson(string id);

    /// <summary>
    /// Gets all <see cref="ApplicationUser"/> records from the database.
    /// </summary>
    /// <returns>A <see cref="List{T}"/> of <see cref="ApplicationUser"/>s.</returns>
    public Task<List<ApplicationUser>> GetAllPersons();

    /// <summary>
    /// Gets the <see cref="ApplicationUser"/> with the given email address.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Task<ApplicationUser?> GetPersonByEmail(string email);
}