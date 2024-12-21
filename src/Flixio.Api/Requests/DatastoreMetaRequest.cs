namespace Flixio.Api.Requests;

public class DatastoreMetaRequest
{
    [JsonPropertyName("authKey")]
    public string AuthKey { get; set; } = null!;
    
    [JsonPropertyName("collection")]
    public string Collection { get; set; } = null!;
}