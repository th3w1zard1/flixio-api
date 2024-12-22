namespace Flixio.Api.Extensions;

public static class EnvironmentalVariablesExtensions
{
    public static bool IsTrue(this string value)
    {
        return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(value));
    }
    
    public static string? GetFromEnvironment(this string value)
    {
        return Environment.GetEnvironmentVariable(value);
    }
}