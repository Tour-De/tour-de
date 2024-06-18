using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourDe.Models;
using TourDe.Services.Interfaces;

namespace TourDe.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly ILogger<IdentityController> _logger;
    private readonly IIdentityService _identityService;

    public IdentityController(ILogger<IdentityController> logger, IIdentityService identityService)
    {
        _logger = logger;
        _identityService = identityService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(ApplicationUser user)
    {
        _logger.LogInformation("User {Email} logged in", user.Email);

        var roles = await _identityService.Login(user);

        return Ok(roles);
    }
}