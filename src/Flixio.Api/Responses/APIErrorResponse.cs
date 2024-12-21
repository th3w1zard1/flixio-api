namespace Flixio.Api.Responses;

public class APIErrorResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("code")]
    public int? Code { get; init; }
}