namespace Flixio.Api.Responses;

public class ModalAddonResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("manifestUrl")]
    public string? ManifestUrl { get; init; }

}