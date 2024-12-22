namespace Flixio.Api.Cors;

public static class CorsServiceCollectionExtensions
{
    public static IServiceCollection SetupAllowedOrigins(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            var allowedOrigins = 
                configuration
                    .GetValue<string>($"{CorsConstants.Configuration.SectionName}:{CorsConstants.Configuration.AllowedOrigins}")
                    ?.Split(';', StringSplitOptions.RemoveEmptyEntries)
                    ?? [];
            
            if (allowedOrigins == null || allowedOrigins.Length == 0)
            {
                throw new InvalidOperationException("No allowed origins are set in configuration.");
            }

            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        CorsConstants.Policy, builder =>
                        {
                            builder.WithOrigins(allowedOrigins)
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        });

                    options.DefaultPolicyName = CorsConstants.Policy;
                });

            return services;
        }
        catch (Exception e)
        {
            Log.Logger.Error(e, "Error setting up allowed origins");
            throw;
        }
    }
}