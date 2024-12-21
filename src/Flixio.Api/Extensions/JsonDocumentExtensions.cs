namespace Flixio.Api.Extensions;

public static class JsonDocumentExtensions
{
    public static async Task<JsonDocument> ToJsonDocument<T>(this T data)
    {
        using var stream = new MemoryStream();
        
        await JsonSerializer.SerializeAsync(stream, data);
        stream.Position = 0;
    
        return await JsonDocument.ParseAsync(stream);
    }
}