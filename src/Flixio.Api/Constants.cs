namespace Flixio.Api;

public static class Constants
{
    public const string DefaultUserId = "67670d7614711aaf5bf0a465";
    public const string DefaultUserEmail = "flixio.user@fake-user.com";
    public const string DefaultAuthKey = "hardcoded-auth-key";

    public static class EnvVars
    {
        public const string ResetDatabase = "FLIXIO_RESET_DATABASE";
        public const string LokiLoggingFormat = "FLIXIO_LOKI_LOGGING_FORMAT";
    }

    public static class CorsPolicies
    {
        public const string AllowAllPolicy = "AllowAll";
    }
}