namespace Flixio.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication SetupFlixio(this WebApplication app)
    {
        app.UseCors(Constants.CorsPolicies.AllowAllPolicy);
        app.RegisterFlixioRoutes();
        app.UseMiddleware<ErrorsMiddleware>();

        return app;
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
            .MapAnalyticsEndpoints();
        
        return app;
    }
}