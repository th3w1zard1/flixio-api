namespace Flixio.Api.Cors;

public static class CorsConfigurationExtensions
{
    public static IConfigurationBuilder AddCorsConfiguration(this IConfigurationBuilder builder)
    {
        try
        {
            var allowedOrigins = CorsConstants.EnvVars.AllowedOrigins.GetFromEnvironment();

            if (string.IsNullOrWhiteSpace(allowedOrigins))
            {
                throw new InvalidOperationException($"Environment variable {CorsConstants.EnvVars.AllowedOrigins} is not set.");
            }

            var corsConfiguration = new Dictionary<string, string>
            {
                [$"{CorsConstants.Configuration.SectionName}:{CorsConstants.Configuration.AllowedOrigins}"] = allowedOrigins
            };

            return builder.AddInMemoryCollection(corsConfiguration!);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e, "Error adding Cors configuration");
            throw;
        }
    }
}