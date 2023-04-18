using Microsoft.AspNetCore.Mvc;
using TourDe.Api.Data;
using TourDe.Models;

namespace TourDe.Api.Controllers;

public class PersonController : Controller
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    /// <summary>
    /// Deletes a <see cref="Person"/>.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("/api/person/{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        await _personRepository.DeletePerson(id);
        return new NoContentResult();
    }

    /// <summary>
    /// Updates the <see cref="Person"/> record.
    /// </summary>
    /// <param name="updatePerson"></param>
    /// <returns></returns>
    [HttpPut("/api/person")]
    public async Task<IActionResult> UpdatePerson(Person updatePerson)
    {
        var person = await _personRepository.UpdatePerson(updatePerson);
        return new OkObjectResult(person);
    }

    /// <summary>
    /// Adds a new <see cref="Person"/> record.
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    [HttpPost("/api/person")]
    public async Task<IActionResult> AddPerson(Person person)
    {
        var id = await _personRepository.AddPerson(person);
        return new CreatedResult($"/api/person/{id}", person);
    }

    /// <summary>
    /// Gets a <see cref="Person"/> by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("/api/person/{id}")]
    public async Task<IActionResult> GetPerson(int id)
    {
        var person = await _personRepository.GetPerson(id);
        if (person is null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(person);
    }

    /// <summary>
    /// Gets all of the <see cref="Person"/>s.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/people")]
    public async Task<IActionResult> GetAllPersons()
    {
        var people = await _personRepository.GetAllPersons();
        return new OkObjectResult(people);
    }
}