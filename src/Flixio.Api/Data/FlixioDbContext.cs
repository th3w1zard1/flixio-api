namespace Flixio.Api.Data;

public class FlixioDbContext(DbContextOptions<FlixioDbContext> options) : DbContext(options)
{
    public DbSet<AddonCollection> AddonCollections => Set<AddonCollection>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<Datastore> Datastores => Set<Datastore>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddonCollection>().ToTable("AddonCollection").HasNoKey();
        modelBuilder.Entity<UserEntity>().ToTable("Users").HasNoKey();
        modelBuilder.Entity<Datastore>().ToTable("Datastore").HasNoKey();
    }
}