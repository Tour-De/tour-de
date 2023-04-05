using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourDe.Data;
using TourDe.Models;

namespace TourDe.Api.Routes;

public static class PersonApi
{
    public static void MapPersonRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/persons", GetAllPersons);

        app.MapGet("/api/person/{id}", GetPerson);

        app.MapPost("/api/person", AddPerson);

        app.MapPut("/api/person/{id}", UpdatePerson);

        app.MapDelete("/api/person/{id}", DeletePerson);
    }

    public static async Task<ActionResult> DeletePerson(TourDeContext db, int id)
    {
        var person = await db.Persons.FindAsync(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        db.Persons.Remove(person);
        await db.SaveChangesAsync();
        return new NotFoundResult();
    }

    public static async Task<ActionResult> UpdatePerson(TourDeContext db, Person updatePerson, int id)
    {
        var person = await db.Persons.FindAsync(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        person.FirstName = updatePerson.FirstName;
        person.LastName = updatePerson.LastName;
        person.DateOfBirth = updatePerson.DateOfBirth;
        await db.SaveChangesAsync();
        return new NotFoundResult();
    }

    public static async Task<ActionResult> AddPerson(TourDeContext db, Person person)
    {
        await db.Persons.AddAsync(person);
        await db.SaveChangesAsync();
        return new CreatedResult($"/person/{person.FirstName}", person);
    }

    public static async Task<ActionResult<Person>> GetPerson(TourDeContext db, int id)
    {
        var person = await db.Persons.FindAsync(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        return person;
    }

    public static async Task<ActionResult<List<Person>>> GetAllPersons(TourDeContext db)
    {
        return await db.Persons.ToListAsync();
    }
}