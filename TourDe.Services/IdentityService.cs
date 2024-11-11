using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Transactions;
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
    public async Task<Result<IList<string>>> Login(ApplicationUser user)
    {
        _logger.LogInformation("Logging in user {UserEmail}", user.Email);

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            return Result.Fail("Email cannot be empty");
        }

        var existingUser = await _userManager.FindByEmailAsync(user.Email);

        if (existingUser == null)
        {
            _logger.LogInformation("User does not exist, creating");

            var userCreateResult = await CreateUser(user);

            if (!userCreateResult.Succeeded)
            {
                return Result.Fail(userCreateResult.Errors.Select(x => x.Description));
            }

            existingUser = await _userManager.FindByEmailAsync(user.Email);

            _logger.LogInformation("User creation successful");
        }

        var roles = await _userManager.GetRolesAsync(existingUser);
        
        _logger.LogInformation("Returning {RoleCount} roles", roles.Count);
        return Result.Ok(roles);
    }

    #region Private Methods

    /// <summary>
    /// Creates the user with the Auth0 login and adds them to the User role.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private async Task<IdentityResult> CreateUser(ApplicationUser user)
    {
        _logger.LogInformation("Creating a new user with email {Email}", user.Email);

        using var transaction = new TransactionScope(asyncFlowOption: TransactionScopeAsyncFlowOption.Enabled);

        // create unique ID
        user.Id = Guid.NewGuid().ToString();

        // create the user record
        var result = await _userManager.CreateAsync(user);
        if (result.Succeeded)
        {
            // add to base user role
            result = await _userManager.AddToRoleAsync(user, IdentityRoles.User);
        }

        if (result.Succeeded)
        {
            // add their Auth0 login info
            var loginInfo = new UserLoginInfo("Auth0", user.NormalizedEmail!, user.UserName);
            result = await _userManager.AddLoginAsync(user, loginInfo);
        }

        if (!result.Succeeded)
        {
            // something went wrong
            _logger.LogError("Unable to create user account: {ErrorMessage}", string.Join(",", result.Errors.Select(x => x.Description)));
            return result;
        }

        // commit the changes
        transaction.Complete();
        return result;
    }

    #endregion
}