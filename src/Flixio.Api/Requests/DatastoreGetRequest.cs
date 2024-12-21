namespace Flixio.Api.Requests;

public class DatastoreGetRequest
{
    [JsonPropertyName("authKey")]
    public string AuthKey { get; set; } = null!;

    [JsonPropertyName("collection")]
    public string Collection { get; set; } = null!;

    [JsonPropertyName("ids")]
    public List<string?> Ids { get; set; } = [];

    [JsonPropertyName("all")]
    public bool All { get; set; }
}