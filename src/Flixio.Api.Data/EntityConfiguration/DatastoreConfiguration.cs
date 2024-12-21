namespace Flixio.Api.Data.EntityConfiguration;

public class DatastoreConfiguration : IEntityTypeConfiguration<Datastore>
{
    public void Configure(EntityTypeBuilder<Datastore> builder)
    {
        builder.ToTable("datastore");
        builder.HasKey(ds => ds.Collection);
        builder.Property(p => p.Collection).HasColumnName("collection");
        builder.Property(p => p.Data).HasColumnName("data")
            .HasConversion(
                m => m.RootElement.ToString(),
                s => JsonDocument.Parse(string.IsNullOrWhiteSpace(s) ? "{}" : s, new()));
    }
}