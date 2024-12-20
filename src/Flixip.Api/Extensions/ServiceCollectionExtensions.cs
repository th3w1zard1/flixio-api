namespace Flixio.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterFlixioDbContext(this IServiceCollection services)
    {
        var dataDir = Path.Combine(AppContext.BaseDirectory, "data");
        
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        
        var dbPath = Path.Combine(dataDir, "flixio.db");
        var connectionString = $"Data Source={dbPath};";
        
        services.AddDbContext<FlixioDbContext>(options =>
            options.UseSqlite(connectionString));

        return services;
    }
    
    public static IServiceCollection RegisterMiddleware(this IServiceCollection services)
    {
        services.AddTransient<HardcodedUserMiddleware>();
        services.AddTransient<ErrorsMiddleware>();
        
        return services;
    }
}