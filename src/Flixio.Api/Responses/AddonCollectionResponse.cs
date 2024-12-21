namespace Flixio.Api.Responses;

public class Addon
{
    [JsonPropertyName("transportUrl")]
    public string TransportUrl { get; set; } = null!;

    [JsonPropertyName("transportName")]
    public string TransportName { get; set; } = null!;

    [JsonPropertyName("manifest")]
    public JsonDocument Manifest { get; set; } = null!;

    [JsonPropertyName("flags")]
    public AddonFlags Flags { get; set; } = null!;
}

public class AddonFlags
{
    [JsonPropertyName("official")]
    public bool Official { get; set; }

    [JsonPropertyName("protected")]
    public bool Protected { get; set; }
}
