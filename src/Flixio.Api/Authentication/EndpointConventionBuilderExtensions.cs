namespace Flixio.Api.Authentication;

public static class EndpointConventionBuilderExtensions
{
    public static IEndpointConventionBuilder RequireApiKeyAuthentication(this IEndpointConventionBuilder builder) =>
        builder
            .RequireAuthorization(ApiKeyAuthenticationConstants.Policy)
            .WithMetadata(new OpenApiSecurityMetadata(ApiKeyAuthenticationConstants.Scheme));
}