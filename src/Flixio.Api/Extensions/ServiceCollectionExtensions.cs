namespace Flixio.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterMiddleware(this IServiceCollection services)
    {
        services.AddTransient<ErrorsMiddleware>();
        
        return services;
    }

    public static IServiceCollection SetupAllowAllCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(Constants.CorsPolicies.AllowAllPolicy, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            
            options.DefaultPolicyName = Constants.CorsPolicies.AllowAllPolicy;
        });
        
        return services;
    }
}