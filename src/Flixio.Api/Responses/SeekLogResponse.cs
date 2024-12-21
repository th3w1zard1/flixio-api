namespace Flixio.Api.Responses;

public class SeekLogResponse
{
    [JsonPropertyName("from")]
    public ulong From { get; init; }

    [JsonPropertyName("to")]
    public ulong To { get; init; }
    
    [JsonPropertyName("success")]
    public bool Success { get; init; }
}