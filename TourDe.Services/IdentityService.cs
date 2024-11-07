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
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityService(ILoggerFactory loggerFactory, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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

            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, IdentityRoles.User);
            }

            if (result.Succeeded)
            {
                var loginInfo = new UserLoginInfo("Auth0", user.NormalizedEmail!, user.UserName);
                result = await _userManager.AddLoginAsync(user, loginInfo);
            }

            if (!result.Succeeded)
            {
                _logger.LogError("Unable to create user account: {ErrorMessage}", string.Join(",", result.Errors.Select(x => x.Description)));
            }
        }

        _logger.LogInformation("Returning roles");
        return await _userManager.GetRolesAsync(user);
    }
}