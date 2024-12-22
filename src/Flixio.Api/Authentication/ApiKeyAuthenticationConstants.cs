namespace Flixio.Api.Authentication;

public static class ApiKeyAuthenticationConstants
{
    public const string Scheme = "ApiKey";
    public const string Policy = "ApiKeyPolicy";
    public const string HeaderName = "X-API-KEY";

    public static class EnvVars
    {
        public const string ApiKey = "FLIXIO_API_KEY";
    }
}
