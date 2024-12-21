namespace Flixio.Api.Data;

public class FlixioDbContext(DbContextOptions<FlixioDbContext> options) : DbContext(options)
{
    public DbSet<AddonCollection> AddonCollections => Set<AddonCollection>();
    public DbSet<Datastore> Datastores => Set<Datastore>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);           
        base.OnModelCreating(modelBuilder);
    }
}