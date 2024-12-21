namespace Flixio.Api.Responses;

public class DatastoreMetaResponse
{
    public List<object[]> Result { get; set; } = [];
    
    public static DatastoreMetaResponse FromJsonDocument(JsonDocument data)
    {
        var result = new List<object[]>();

        if (!data.RootElement.TryGetProperty("result", out var resultElement) || resultElement.ValueKind is not JsonValueKind.Array)
        {
            return new();
        }
        
        foreach (var item in resultElement.EnumerateArray())
        {
            var id = item.GetProperty("_id").GetString();
            var timestamp = item.GetProperty("_mtime").GetDateTimeOffset().ToUnixTimeSeconds();
            
            if (id is null || timestamp == 0)
            {
                continue;
            }
            
            result.Add([id, timestamp]);
        }
        
        return new() { Result = result };
    }
}