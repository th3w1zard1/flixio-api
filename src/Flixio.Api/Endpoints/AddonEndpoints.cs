namespace Flixio.Api.Endpoints;

public static class AddonEndpoints
{
    private const string UpdateAddonsEndpoint = "/addonCollectionSet";
    private const string GetAddonsEndpoint = "/addonCollectionGet";

    public static RouteGroupBuilder MapAddonEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(UpdateAddonsEndpoint, UpdateAddonCollection);
        group.MapPost(GetAddonsEndpoint, GetAddonCollection);

        return group;
    }
    
    private static async Task<IResult> GetAddonCollection(FlixioDbContext db)
    {
        var addonCollection = await db.AddonCollections.FindAsync(Constants.DefaultAuthKey);
        if (addonCollection == null)
            return Results.NotFound(new APIError("Collection not found", 404));

        var addons = JsonSerializer.Deserialize<List<Descriptor>>(addonCollection.Addons) ?? [];
        return Results.Ok(new CollectionResponse(addons, addonCollection.LastModified));
    }

    private static async Task<IResult> UpdateAddonCollection(AddonCollectionSetRequest request, FlixioDbContext db)
    {
        var addonCollection = await db.AddonCollections.FindAsync(Constants.DefaultAuthKey);
        if (addonCollection == null)
        {
            addonCollection = new()
            {
                AuthKey = Constants.DefaultAuthKey,
                Addons = JsonSerializer.Serialize(request.Addons),
                LastModified = DateTime.UtcNow,
            };
            db.AddonCollections.Add(addonCollection);
        }
        else
        {
            addonCollection.Addons = JsonSerializer.Serialize(request.Addons);
            addonCollection.LastModified = DateTime.UtcNow;
        }
        await db.SaveChangesAsync();
        return Results.Ok(new SuccessResponse(true));
    }
}