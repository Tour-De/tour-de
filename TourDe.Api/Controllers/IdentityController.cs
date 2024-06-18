using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TourDe.Core;
using TourDe.Models;

namespace TourDe.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly ILogger<IdentityController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityController(ILogger<IdentityController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(ApplicationUser user)
    {
        _logger.LogInformation("User {Email} logged in", user.Email);

        var doesUserExist = await _userManager.FindByEmailAsync(user.Email);

        if (doesUserExist == null)
        {
            await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, IdentityRoles.User);
        }

        return Ok();
    }
}