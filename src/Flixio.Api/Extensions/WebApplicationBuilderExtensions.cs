namespace Flixio.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder SetupOtlp(this WebApplicationBuilder builder)
    {
        Environment.SetEnvironmentVariable("OTEL_EXPOSE_HEALTHCHECKS", "true");
        builder.AddOtlpServiceDefaults(lokiCompatible: Constants.EnvVars.LokiLoggingFormat.IsTrue());
        
        return builder;
    }
}