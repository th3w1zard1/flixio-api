namespace Flixio.Api.Data.EntityConfiguration;

public class AddonCollectionConfiguration : IEntityTypeConfiguration<AddonCollection>
{
    public void Configure(EntityTypeBuilder<AddonCollection> builder)
    {
        builder.ToTable("addon_collection");
        builder.HasKey(ac => ac.Id);
        builder.Property(ac => ac.Addons).HasColumnName("addons")
            .HasConversion(
                m => m.RootElement.ToString(),
                s => JsonDocument.Parse(string.IsNullOrWhiteSpace(s) ? "{}" : s, new()));
        builder.Property(ac => ac.LastModified).HasColumnName("last_modified");
    }
}