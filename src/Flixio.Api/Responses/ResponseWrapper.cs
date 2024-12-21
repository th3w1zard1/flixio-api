namespace Flixio.Api.Responses;

public class ResponseWrapper
{
    [JsonPropertyName("result")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Result { get; set; }
    
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public APIErrorResponse? Error { get; set; }
    
    [JsonPropertyName("success")]
    public bool Success => Error == null;

    
    public static ResponseWrapper ErrorResponse(string message, int code = 999)
        => new()
        {
            Error = new()
            {
                Message = message,
                Code = code,
            },
        };

    public static ResponseWrapper SuccessResponse<TResponse>(TResponse? result) =>
        new()
        {
            Result = result,
        };
}