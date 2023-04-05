using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourDe.Api.Data;
using TourDe.Models;

namespace TourDe.Api.Routes;

public static class PersonApi
{
    /// <summary>
    /// Maps all the /person routes.
    /// </summary>
    /// <param name="app"></param>
    public static void MapPersonRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/persons", GetAllPersons);

        app.MapGet("/api/person/{id}", GetPerson);

        app.MapPost("/api/person", AddPerson);

        app.MapPut("/api/person/{id}", UpdatePerson);

        app.MapDelete("/api/person/{id}", DeletePerson);
    }

    /// <summary>
    /// Deletes a <see cref="Person"/>.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="id"></param>
    /// <returns>A <see cref="NotFoundResult"/> if the <see cref="Person"/> record doesn't exist. Otherwise <see cref="NoContentResult"/>.</returns>
    public static async Task<ActionResult> DeletePerson(DatabaseContext db, int id)
    {
        var person = await db.Persons.FindAsync(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        db.Persons.Remove(person);
        await db.SaveChangesAsync();
        return new NoContentResult();
    }

    /// <summary>
    /// Updates the <see cref="Person"/> record.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="updatePerson"></param>
    /// <param name="id"></param>
    /// <returns>A <see cref="NotFoundResult"/> if the <see cref="Person"/> record doesn't exist. Otherwise <see cref="OkObjectResult"/> containing the updated data.</returns>
    public static async Task<ActionResult> UpdatePerson(DatabaseContext db, Person updatePerson, int id)
    {
        var person = await db.Persons.FindAsync(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        db.Persons.Entry(person).CurrentValues.SetValues(updatePerson);
        await db.SaveChangesAsync();
        return new OkObjectResult(person);
    }

    /// <summary>
    /// Adds a new <see cref="Person"/> record.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="person"></param>
    /// <returns>A <see cref="CreatedResult"/> containing the URI of the new person record.</returns>
    public static async Task<ActionResult> AddPerson(DatabaseContext db, Person person)
    {
        await db.Persons.AddAsync(person);
        await db.SaveChangesAsync();
        return new CreatedResult("/api/person/{person.Id}", person);
    }

    /// <summary>
    /// Gets a <see cref="Person"/> by ID.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="id"></param>
    /// <returns>A <see cref="NotFoundResult"/> if the <see cref="Person"/> record doesn't exist. Otherwise a <see cref="OkObjectResult"/> containing the record.</returns>
    public static async Task<ActionResult<Person>> GetPerson(DatabaseContext db, int id)
    {
        var person = await db.Persons.FindAsync(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        return person;
    }

    /// <summary>
    /// Gets all of the <see cref="Person"/>s.
    /// </summary>
    /// <param name="db"></param>
    /// <returns>A list of the <see cref="Person"/>s.</returns>
    public static async Task<ActionResult<List<Person>>> GetAllPersons(DatabaseContext db)
    {
        return await db.Persons.ToListAsync();
    }
}