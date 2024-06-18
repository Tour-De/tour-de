using TourDe.Core.Exceptions;

namespace TourDe.Api.Extensions;

public static class AuthorizationServicesExtensions
{
    /// <summary>
    /// Adds the appropriate auth provider (Auth0) based on configuration settings.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="MissingConfigurationException"></exception>
    public static IServiceCollection AddAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var authBuilder = services.AddAuthentication();
        authBuilder.AddJwtBearer(options =>
        {
            options.Authority = configuration["Authentication:Auth0:Domain"];
            options.Audience = configuration["Authentication:Auth0:Audience"] ?? throw new MissingConfigurationException("Authentication:Auth0:Audience");
        });
        
        return services;
    }
}