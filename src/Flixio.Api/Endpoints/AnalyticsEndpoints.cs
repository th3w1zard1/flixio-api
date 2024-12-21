namespace Flixio.Api.Endpoints;

public static class AnalyticsEndpoints
{
    private const string EventsEndpoint = "/events";

    public static RouteGroupBuilder MapAnalyticsEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(EventsEndpoint, Events);

        return group;
    }
    
    private static async Task Events(HttpContext context)
    {
        if (context.Request.ContentType != "text/plain;charset=UTF-8")
        {
            context.Response.StatusCode = StatusCodes.Status415UnsupportedMediaType;
            await context.Response.WriteAsJsonAsync(CommonResponses.UnsupportedMediaTypeResponse);
            return;
        }

        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

        EventsRequest? data;
        try
        {
            data = JsonSerializer.Deserialize<EventsRequest>(requestBody);
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(CommonResponses.InvalidJsonResponse);
            return;
        }

        if (data == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(CommonResponses.EmptyPayloadResponse);
            return;
        }
        
        await context.Response.WriteAsJsonAsync(SuccessResponse);
    }
    
    private static ResponseWrapper SuccessResponse => 
        ResponseWrapper.SuccessResponse(GenericSuccessResponse.WithMessage("Events received."));
}