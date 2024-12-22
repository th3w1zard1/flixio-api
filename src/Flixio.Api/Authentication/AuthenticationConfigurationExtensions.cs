namespace Flixio.Api.Authentication;

public static class AuthenticationConfigurationExtensions
{
    public static IConfigurationBuilder AddAuthenticationConfiguration(this IConfigurationBuilder builder)
    {
        try
        {
            var apiKey = ApiKeyAuthenticationConstants.EnvVars.ApiKey.GetFromEnvironment();

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException($"Environment variable {ApiKeyAuthenticationConstants.EnvVars.ApiKey} is not set.");
            }

            var authConfiguration = new Dictionary<string, string>
            {
                [$"{AuthenticationConfiguration.SectionName}:{nameof(AuthenticationConfiguration.ApiKey)}"] = apiKey,
            };

            return builder.AddInMemoryCollection(authConfiguration!);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e, "Error adding Authentication configuration");
            throw;
        }
    }
}