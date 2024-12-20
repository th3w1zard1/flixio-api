namespace Flixio.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder SetupOtlp(this WebApplicationBuilder builder)
    {
        Environment.SetEnvironmentVariable("OTEL_EXPOSE_HEALTHCHECKS", "true");
        var lokiCompatibleLogging = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LOKI_LOGGING_FORMAT"));
        
        builder.AddOtlpServiceDefaults(lokiCompatible: lokiCompatibleLogging);
        
        return builder;
    }
}