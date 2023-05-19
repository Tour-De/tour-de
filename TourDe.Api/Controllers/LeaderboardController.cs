using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourDe.Api.Data;

namespace TourDe.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaderboardController : Controller
{
    private readonly IPersonRepository _personRepository;

    public LeaderboardController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetLeaderBoard()
    {
        var people = await _personRepository.GetAllPersons();
        return Ok(people);
    }
}