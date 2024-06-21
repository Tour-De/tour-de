using TourDe.Core;
using TourDe.Models;

namespace TourDe.Services.Interfaces;

public interface IIdentityService
{
    /// <summary>
    /// Logs the user in, adding them if they don't exist as a <see cref="IdentityRoles.User"/>, and returns their assigned roles.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<IList<string>> Login(ApplicationUser user);
}