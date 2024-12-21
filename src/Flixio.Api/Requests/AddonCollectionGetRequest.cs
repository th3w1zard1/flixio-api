namespace Flixio.Api.Requests;

public class AddonCollectionGetRequest
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("authKey")]
    public string AuthKey { get; set; } = null!;

    [JsonPropertyName("update")]
    public bool Update { get; set; }
}