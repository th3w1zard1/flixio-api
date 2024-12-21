namespace Flixio.Api.Responses;

public static class CommonResponses
{
    public static ResponseWrapper InvalidJsonResponse =>
        ResponseWrapper.ErrorResponse("Invalid JSON format in request body.", 400);

    public static ResponseWrapper UnsupportedMediaTypeResponse => 
        ResponseWrapper.ErrorResponse("Unsupported media type. Please send text/plain;charset=UTF-8.", 415);

    public static ResponseWrapper EmptyPayloadResponse =>
        ResponseWrapper.ErrorResponse("Empty or null payload.", 400);

    public static IResult GenericSuccessResponse =>
        Results.Json(
            new
            {
                result = new
                {
                    success = true,
                },
            });
}