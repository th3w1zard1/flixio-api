namespace Flixio.Api.Responses;

public class GenericSuccessResponse
{
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }

    public static GenericSuccessResponse Default => new();
    
    public static GenericSuccessResponse WithMessage(string message) => new()
    {
        Message = message,
    };
}