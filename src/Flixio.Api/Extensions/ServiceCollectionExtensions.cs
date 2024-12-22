namespace Flixio.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterMiddleware(this IServiceCollection services)
    {
        services.AddTransient<ErrorsMiddleware>();
        
        return services;
    }
}