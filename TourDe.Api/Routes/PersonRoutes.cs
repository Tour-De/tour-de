using Microsoft.AspNetCore.Mvc;
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
    /// <param name="repository"></param>
    /// <param name="id"></param>
    /// <returns>A <see cref="NotFoundResult"/> if the <see cref="Person"/> record doesn't exist. Otherwise <see cref="NoContentResult"/>.</returns>
    public static async Task<ActionResult> DeletePerson(IPersonRepository repository, int id)
    {
        return await repository.DeletePerson(id) ? new NoContentResult() : new NotFoundResult();
    }

    /// <summary>
    /// Updates the <see cref="Person"/> record.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="updatePerson"></param>
    /// <param name="id"></param>
    /// <returns>A <see cref="NotFoundResult"/> if the <see cref="Person"/> record doesn't exist. Otherwise <see cref="OkObjectResult"/> containing the updated data.</returns>
    public static async Task<ActionResult> UpdatePerson(IPersonRepository repository, Person updatePerson, int id)
    {
        var person = await repository.UpdatePerson(updatePerson);
        if (person is null)
        {
            return new NotFoundResult();
        }
        return new OkObjectResult(person);
    }

    /// <summary>
    /// Adds a new <see cref="Person"/> record.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="person"></param>
    /// <returns>A <see cref="CreatedResult"/> containing the URI of the new person record.</returns>
    public static async Task<ActionResult> AddPerson(IPersonRepository repository, Person person)
    {
        var id = await repository.AddPerson(person);
        return new CreatedResult($"/api/person/{id}", person);
    }

    /// <summary>
    /// Gets a <see cref="Person"/> by ID.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="id"></param>
    /// <returns>A <see cref="NotFoundResult"/> if the <see cref="Person"/> record doesn't exist. Otherwise a <see cref="OkObjectResult"/> containing the record.</returns>
    public static async Task<ActionResult> GetPerson(IPersonRepository repository, int id)
    {
        var person = await repository.GetPerson(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(person);
    }

    /// <summary>
    /// Gets all of the <see cref="Person"/>s.
    /// </summary>
    /// <param name="repository"></param>
    /// <returns>A list of the <see cref="Person"/>s.</returns>
    public static async Task<ActionResult<List<Person>>> GetAllPersons(IPersonRepository repository)
    {
        return await repository.GetAllPersons();
    }
}