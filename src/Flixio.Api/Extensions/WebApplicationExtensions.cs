namespace Flixio.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication SetupFlixio(this WebApplication app)
    {
        app.UseCors(CorsConstants.Policy);
        app.UseApiKeyAuthentication();
        app.RegisterFlixioRoutes();
        app.UseMiddleware<ErrorsMiddleware>();

        return app;
    }

    public static async Task LogConfigurationValues(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        
        logger.LogInformation("Allowed Origins: {AllowedOrigins}", CorsConstants.EnvVars.AllowedOrigins.GetFromEnvironment());
        logger.LogInformation("Using Api Key Authentication: {ApiKeyAuthentication}", ApiKeyAuthenticationConstants.EnvVars.ApiKey.GetFromEnvironment());
    }
    
    public static async Task SetupDatabase(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<FlixioDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        if (Constants.EnvVars.ResetDatabase.IsTrue())
        {
            await dbContext.Database.EnsureDeletedAsync();
            logger.LogInformation("Database reset");
        }

        await dbContext.Database.EnsureCreatedAsync();
        
        logger.LogInformation("Database: {Database}", dbContext.Database.GetDbConnection().Database);
        logger.LogInformation("Database Connection: {DatabaseConnection}", dbContext.Database.GetDbConnection().ConnectionString);
    }
    
    private static WebApplication RegisterFlixioRoutes(this WebApplication app)
    {
        app.MapDefaultEndpoints();

        app.MapGroup("api")
            .WithTags("api")
            .MapAddonEndpoints()
            .MapAuthEndpoints()
            .MapDatastoreEndpoints()
            .MapGeneralEndpoints()
            .MapAnalyticsEndpoints()
            .RequireApiKeyAuthentication();
        
        return app;
    }
    
    private static WebApplication UseApiKeyAuthentication(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}