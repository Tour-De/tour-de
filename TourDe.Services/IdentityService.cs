using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TourDe.Core;
using TourDe.Models;
using TourDe.Services.Interfaces;

namespace TourDe.Services;

public sealed class IdentityService: IIdentityService
{
    private readonly ILogger _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(ILoggerFactory loggerFactory, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _logger = loggerFactory.CreateLogger<IdentityService>();
    }

    /// <inheritdoc />
    public async Task<IList<string>> Login(ApplicationUser user)
    {
        _logger.LogInformation("Logging in user {UserEmail}", user.Email);

        var doesUserExist = await _userManager.FindByEmailAsync(user.Email);

        if (doesUserExist == null)
        {
            _logger.LogInformation("User does not exist, creating");

            await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, IdentityRoles.User);
        }

        _logger.LogInformation("Returning roles");
        return await _userManager.GetRolesAsync(user);
    }
}