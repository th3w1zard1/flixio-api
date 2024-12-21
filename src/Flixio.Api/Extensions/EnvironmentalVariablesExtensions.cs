namespace Flixio.Api.Extensions;

public static class EnvironmentalVariablesExtensions
{
    public static bool IsTrue(this string value)
    {
        return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(value));
    }
}