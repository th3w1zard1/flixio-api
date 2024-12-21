namespace Flixio.Api.Responses;

public class SeriesInfoResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }

    [JsonPropertyName("episode")]
    public int? Episode { get; init; }
}