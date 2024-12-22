namespace Flixio.Api.Authentication;

public sealed class OpenApiSecurityMetadata(string securityScheme)
{
    public string SecurityScheme { get; } = securityScheme;
}
