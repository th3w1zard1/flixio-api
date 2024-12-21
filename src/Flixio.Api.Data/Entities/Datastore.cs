namespace Flixio.Api.Data.Entities;

public class Datastore
{
    public string Collection { get; set; } = null!;
    public JsonDocument Data { get; set; } = null!;
}