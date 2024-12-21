namespace Flixio.Api.Data.Extensions;

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
        
        services.AddDbContextFactory<FlixioDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Datastore, string>, DatastoreRepository>();
        services.AddScoped<IRepository<AddonCollection, int>, AddonCollectionRepository>();

        return services;
    }
}