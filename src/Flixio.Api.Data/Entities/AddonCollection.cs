namespace Flixio.Api.Data.Entities;

public class AddonCollection
{
    public int Id { get; set; }
    public JsonDocument Addons { get; set; } = null!;
    public DateTime LastModified { get; set; }
}