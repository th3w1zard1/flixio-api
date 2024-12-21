namespace Flixio.Api.Endpoints;

public static class AddonEndpoints
{
    private const string SetAddonsEndpoint = "/addonCollectionSet";
    private const string GetAddonsEndpoint = "/addonCollectionGet";

    public static RouteGroupBuilder MapAddonEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(SetAddonsEndpoint, SetAddonCollection);
        group.MapPost(GetAddonsEndpoint, GetAddonCollection);

        return group;
    }

    private static async Task GetAddonCollection(HttpContext context, IServiceProvider serviceProvider) =>
        await context.HandleStremioRequest<AddonCollectionGetRequest>(
            async _ =>
            {
                await using var scope = serviceProvider.CreateAsyncScope();
                var addonRepository = scope.ServiceProvider.GetRequiredService<IRepository<AddonCollection, int>>();
                var addonCollection = await addonRepository.GetAsync(1);

                return addonCollection is null ? ReturnDefaultAddonCollection() : ExistingAddonResponse(addonCollection);
            });

    private static async Task SetAddonCollection(HttpContext context, IServiceProvider serviceProvider) =>
        await context.HandleStremioRequest<AddonCollectionSetRequest>(
            async request  =>
            {
                await using var scope = serviceProvider.CreateAsyncScope();
                var addonRepository = scope.ServiceProvider.GetRequiredService<IRepository<AddonCollection, int>>();
                var addonCollection = await addonRepository.GetAsync(1);

                if (addonCollection is null)
                {
                    var newCollection = new AddonCollection
                    {
                        Id = 1,
                        Addons = await request.Addons.ToJsonDocument(),
                        LastModified = DateTime.UtcNow,
                    };
                    
                    await addonRepository.AddAsync(newCollection);
                    return CommonResponses.GenericSuccessResponse;
                }

                addonCollection.Addons = await request.Addons.ToJsonDocument();
                addonCollection.LastModified = DateTime.UtcNow;
                await addonRepository.UpdateAsync(addonCollection);
                
                return CommonResponses.GenericSuccessResponse;
            });
    
    private static IResult ExistingAddonResponse(AddonCollection? addonCollection) =>
        Results.Json(
            new
            {
                result = new
                {
                    addons = addonCollection?.Addons ?? JsonDocument.Parse("[]"),
                    isInitial = false,
                    lastModified = addonCollection?.LastModified.ToString("yyyy-MM-ddTHH:mm:ssZ") ?? DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                },
            });
    
    private static IResult ReturnDefaultAddonCollection() => 
        Results.Text(StaticAddonResults.DefaultAddonCollectionResult(DateTime.UtcNow));
}