namespace Flixio.Api.Extensions;

public static class HttpContextExtensions
{
    public static async Task HandleStremioRequest<TRequest>(
        this HttpContext context,
        Func<TRequest, Task<IResult>> processRequest)
    {
        if (context.Request.ContentType != "text/plain;charset=UTF-8")
        {
            context.Response.StatusCode = StatusCodes.Status415UnsupportedMediaType;
            await context.Response.WriteAsJsonAsync(CommonResponses.UnsupportedMediaTypeResponse);
            return;
        }

        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

        try
        {
            var request = JsonSerializer.Deserialize<TRequest>(requestBody);

            if (request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(CommonResponses.EmptyPayloadResponse);
                return;
            }

            var result = await processRequest(request);
            await result.ExecuteAsync(context);
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(CommonResponses.InvalidJsonResponse);
        }
    }
}