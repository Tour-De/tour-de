using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TourDe.Models;
using TourDe.Services.Interfaces;

namespace TourDe.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly ILogger<IdentityController> _loggerFactory;
    private readonly IIdentityService _identityService;

    public IdentityController(ILoggerFactory loggerFactory, IIdentityService identityService)
    {
        _loggerFactory = loggerFactory.CreateLogger<IdentityController>();
        _identityService = identityService;
    }

    /// <summary>
    /// Returns the list of roles that apply to the user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns>A list of roles.</returns>
    [HttpPost]
    [ProducesResponseType<IList<string>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Login(ApplicationUser user)
    {
        _loggerFactory.LogInformation("User {Email} logged in", user.Email);

        if (string.IsNullOrEmpty(user.Email))
        {
            return BadRequest("Email is required");
        }

        var roles = await _identityService.Login(user);

        return Ok(roles);
    }
}