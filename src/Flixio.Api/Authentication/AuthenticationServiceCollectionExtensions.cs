namespace Flixio.Api.Authentication;

public static class AuthenticationServiceCollectionExtensions
{
    public static IServiceCollection RegisterAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationConfiguration>(configuration.GetSection(AuthenticationConfiguration.SectionName));

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = "None";
                options.DefaultAuthenticateScheme = "None";
            })
            .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationConstants.Scheme, _ => { });

        services.AddAuthorizationBuilder()
            .AddPolicy(ApiKeyAuthenticationConstants.Policy, policy =>
            {
                policy.AuthenticationSchemes.Add(ApiKeyAuthenticationConstants.Scheme);
                policy.RequireAuthenticatedUser();
            });

        return services;
    }
}