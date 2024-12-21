namespace Flixio.Api.Endpoints;

public static class GeneralEndpoints
{
    private const string GetModalEndpoint = "/getModal";
    private const string GetNotificationEndpoint = "/getNotification";
    private const string SeekLogEndpoint = "/seekLog";
    private const string SkipGapsEndpoint = "/getSkipGaps";
    private const string DataExportEndpoint = "/dataExport";

    public static RouteGroupBuilder MapGeneralEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(GetModalEndpoint, GetModal);
        group.MapPost(GetNotificationEndpoint, GetNotification);
        group.MapPost(SeekLogEndpoint, SeekLog);
        group.MapPost(SkipGapsEndpoint, SkipGaps);
        group.MapPost(DataExportEndpoint, DataExport);

        return group;
    }

    private static IResult GetModal([FromBody] GetModalRequest request) =>
        Results.Ok(ResponseWrapper.SuccessResponse(new ModalResponse("id", "title", "message", "image_url", null, null)));

    private static IResult GetNotification([FromBody] GetNotificationRequest request) =>
        Results.Ok(ResponseWrapper.SuccessResponse(new NotificationResponse("id", "title", "message", null)));

    private static IResult SeekLog([FromBody] SeekLogRequest request) =>
        Results.Ok(ResponseWrapper.SuccessResponse(new SeekLogResponse()));

    private static IResult SkipGaps([FromBody] SkipGapsRequest request) =>
        Results.Ok(ResponseWrapper.SuccessResponse(new SkipGapsResponse()));

    private static IResult DataExport() =>
        Results.Ok();
}