namespace Flixio.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder SetupOtlp(this WebApplicationBuilder builder)
    {
        var lokiCompatible = Constants.EnvVars.LokiLoggingFormat.IsTrue();
        builder.AddOtlpServiceDefaults(lokiCompatible: lokiCompatible, rawCompactJson: lokiCompatible);
        
        return builder;
    }
}