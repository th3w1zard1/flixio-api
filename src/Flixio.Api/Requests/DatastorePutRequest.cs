namespace Flixio.Api.Requests;

public class DatastorePutRequest
{
    [JsonPropertyName("authKey")]
    public string AuthKey { get; set; } = null!;

    [JsonPropertyName("collection")]
    public string Collection { get; set; } = null!;

    [JsonPropertyName("changes")]
    public List<JsonElement> Changes { get; set; } = new();
}