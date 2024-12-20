namespace Flixio.Api.Endpoints;

public static class DataEndpoints
{
    private const string GetModalEndpoint = "/getModal";
    private const string GetNotificationEndpoint = "/getNotification";
    private const string SeekLogEndpoint = "/seekLog";
    private const string SkipGapsEndpoint = "/getSkipGaps";
    private const string DataExportEndpoint = "/dataExport";
    private const string DatastorePutEndpoint = "/datastorePut";
    private const string DatastoreGetEndpoint = "/datastoreGet";
    private const string DatastoreMetaEndpoint = "/datastoreMeta";
    private const string EventsEndpoint = "/events";
    
    public static RouteGroupBuilder MapDataEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(GetModalEndpoint, GetModal);
        group.MapPost(GetNotificationEndpoint, GetNotification);
        group.MapPost(SeekLogEndpoint, SeekLog);
        group.MapPost(SkipGapsEndpoint, SkipGaps);
        group.MapPost(DataExportEndpoint, DataExport);
        group.MapPost(DatastorePutEndpoint, DatastorePut);
        group.MapPost(DatastoreGetEndpoint, DatastoreGet);
        group.MapPost(DatastoreMetaEndpoint, DatastoreMeta);
        group.MapPost(EventsEndpoint, Events);
        
        return group;
    }

    private static IResult GetModal([FromBody] GetModalRequest request) =>
        Results.Ok(new ModalResponse("id", "title", "message", "image_url", null, null));

    private static IResult GetNotification([FromBody] GetNotificationRequest request) =>
        Results.Ok(new NotificationResponse("id", "title", "message", null));

    private static IResult SeekLog([FromBody] SeekLogRequest request) =>
        Results.Ok(new SeekLogResponse(true));

    private static IResult SkipGaps([FromBody] SkipGapsRequest request) =>
        Results.Ok(new SkipGapsResponse("exact", new()));

    private static IResult DataExport() =>
        Results.Ok(new {ExportId = "dummyExportId", IsNew = true});

    private static async Task<IResult> DatastorePut(DatastoreRequest request, FlixioDbContext db)
    {
        var datastore = await db.Datastores.FindAsync(request.Collection);
        if (datastore == null)
        {
            datastore = new()
            {
                Collection = request.Collection,
                Data = JsonSerializer.Serialize(request.Command.Payload)
            };
            db.Datastores.Add(datastore);
        }
        else
        {
            datastore.Data = JsonSerializer.Serialize(request.Command.Payload);
        }
        await db.SaveChangesAsync();
        return Results.Ok(new SuccessResponse(true));
    }
    
    private static async Task<IResult> DatastoreGet(DatastoreRequest request, FlixioDbContext db)
    {
        var datastore = await db.Datastores.FindAsync(request.Collection);
        if (datastore == null)
            return Results.NotFound(new APIError("Collection not found", 404));

        var data = JsonSerializer.Deserialize<object>(datastore.Data);
        
        return data == null ? Results.NotFound(new APIError("Data not found", 404)) : Results.Ok(new DatastoreResponse(data));
    }
    
    private static IResult DatastoreMeta() =>
        Results.Ok(new {Meta = new[] {new {Key = "ExampleKey", Value = "ExampleValue"}}});
    
    
    private static IResult Events([FromBody] EventsRequest request) =>
        Results.Ok(new SuccessResponse(true));
}