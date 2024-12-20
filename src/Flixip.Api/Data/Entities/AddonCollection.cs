namespace Flixio.Api.Data.Entities;

public class AddonCollection
{
    public string AuthKey { get; set; } = null!;
    public string Addons { get; set; } = null!;
    public DateTime LastModified { get; set; }
}