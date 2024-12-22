namespace Flixio.Api.Cors;

public static class CorsConstants
{
    public const string Policy = "CorsPolicy";

    public static class EnvVars
    {
        public const string AllowedOrigins = "FLIXIO_CORS_ALLOWED_ORIGINS";
    }
    
    public static class Configuration
    {
        public const string SectionName = "CorsConfiguration";
        public const string AllowedOrigins = "AllowedOrigins";
    }
}
