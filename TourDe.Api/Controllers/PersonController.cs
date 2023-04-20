using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourDe.Api.Authorization;
using TourDe.Api.Data;
using TourDe.Models;

namespace TourDe.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
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
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        await _personRepository.DeletePerson(id);
        return NoContent();
    }

    /// <summary>
    /// Updates the <see cref="Person"/> record.
    /// </summary>
    /// <param name="updatePerson"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdatePerson(Person updatePerson)
    {
        var person = await _personRepository.UpdatePerson(updatePerson);
        return Ok(person);
    }

    /// <summary>
    /// Adds a new <see cref="Person"/> record.
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddPerson(Person person)
    {
        await _personRepository.AddPerson(person);
        return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
    }

    /// <summary>
    /// Gets a <see cref="Person"/> by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetPerson")]
    [Authorize(Policies.ReadPersonPolicyName)]
    public async Task<IActionResult> GetPerson(int id)
    {
        var person = await _personRepository.GetPerson(id);
        if (person is null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    /// <summary>
    /// Gets all of the <see cref="Person"/>s.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Policies.ReadPersonPolicyName)]
    public async Task<IActionResult> GetAllPersons()
    {
        var people = await _personRepository.GetAllPersons();
        return Ok(people);
    }
}