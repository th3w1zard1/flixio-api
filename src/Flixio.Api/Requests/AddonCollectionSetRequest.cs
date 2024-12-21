namespace Flixio.Api.Requests;

public class AddonCollectionSetRequest
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("authKey")]
    public string AuthKey { get; set; } = null!;

    [JsonPropertyName("addons")]
    public List<Addon> Addons { get; set; } = [];
}