namespace Flixio.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication SetupFlixio(this WebApplication app)
    {
        app.UseMiddleware<HardcodedUserMiddleware>();
        app.RegisterFlixioRoutes();
        app.UseMiddleware<ErrorsMiddleware>();

        return app;
    }
    
    public static async Task LogStartup(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<FlixioDbContext>();
        
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Starting Flixio API");
        logger.LogInformation("Environment: {Environment}", app.Environment.EnvironmentName);
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
            .MapDataEndpoints();
        
        return app;
    }
}