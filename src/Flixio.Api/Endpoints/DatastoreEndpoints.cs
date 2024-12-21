namespace Flixio.Api.Endpoints;

public static class DatastoreEndpoints
{
    private const string DatastorePutEndpoint = "/datastorePut";
    private const string DatastoreGetEndpoint = "/datastoreGet";
    private const string DatastoreMetaEndpoint = "/datastoreMeta";
    
    public static RouteGroupBuilder MapDatastoreEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(DatastorePutEndpoint, DatastorePut);
        group.MapPost(DatastoreGetEndpoint, DatastoreGet);
        group.MapPost(DatastoreMetaEndpoint, DatastoreMeta);
        
        return group;
    }

    private static async Task DatastorePut(HttpContext context, IServiceProvider serviceProvider) =>
        await context.HandleStremioRequest<DatastorePutRequest>(
            async request =>
            {
                await using var scope = serviceProvider.CreateAsyncScope();
                var datastoreRepository = scope.ServiceProvider.GetRequiredService<IRepository<Datastore, string>>();
                var datastore = await datastoreRepository.GetAsync(request.Collection) ?? new Datastore
                {
                    Collection = request.Collection,
                    Data = JsonDocument.Parse("{\"result\": []}"),
                };
        
                var existingItems = datastore.Data.RootElement
                    .GetProperty("result")
                    .EnumerateArray()
                    .ToDictionary(item => item.GetProperty("_id").GetString()!, item => item);
        
                foreach (var change in request.Changes)
                {
                    var id = change.GetProperty("_id").GetString();
                    if (id == null)
                    {
                        continue;
                    }
                    
                    existingItems[id] = change;
                }

                var updatedResult = existingItems.Values.ToList();
                var json = new {result = updatedResult};
                datastore.Data = await json.ToJsonDocument();
                await datastoreRepository.UpdateAsync(datastore);

                return SuccessResponse;
            });

    private static async Task DatastoreGet(HttpContext context, IServiceProvider serviceProvider) =>
        await context.HandleStremioRequest<DatastoreGetRequest>(
            async request =>
            {
                await using var scope = serviceProvider.CreateAsyncScope();
                var datastoreRepository = scope.ServiceProvider.GetRequiredService<IRepository<Datastore, string>>();
                var datastore = await datastoreRepository.GetAsync(request.Collection);

                if (datastore == null)
                {
                    return await InitializeDatastore(request.Collection, datastoreRepository);
                }

                var json = datastore.Data.RootElement.GetProperty("result");

                if (request.All)
                {
                    return Results.Json(new {result = json});
                }

                var filteredItems = json
                    .EnumerateArray()
                    .Where(item => request.Ids.Contains(item.GetProperty("_id").GetString()))
                    .ToList();

                return Results.Json(new {result = filteredItems});
            });

    private static async Task DatastoreMeta(HttpContext context, IServiceProvider serviceProvider) =>
        await context.HandleStremioRequest<DatastoreMetaRequest>(
            async request =>
            {
                await using var scope = serviceProvider.CreateAsyncScope();
                var datastoreRepository = scope.ServiceProvider.GetRequiredService<IRepository<Datastore, string>>();
                
                var datastore = await datastoreRepository.GetAsync(request.Collection);

                if (datastore is null)
                {
                    return await InitializeDatastore(request.Collection, datastoreRepository);
                }

                var response = DatastoreMetaResponse.FromJsonDocument(datastore.Data);
                return Results.Json(response);
            });

    private static async Task<IResult> InitializeDatastore(string collection, IRepository<Datastore, string> datastoreRepository)
    {
        Datastore datastore = new()
        {
            Collection = collection,
            Data = JsonDocument.Parse("{\"result\": []}"),
        };
                    
        await datastoreRepository.AddAsync(datastore);
        return Results.Json(DatastoreMetaResponse.FromJsonDocument(datastore.Data));
    }

    private static IResult SuccessResponse =>
        Results.Json(
            new
            {
                result = new
                {
                    success = true,
                },
            });
}