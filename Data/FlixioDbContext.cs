using Microsoft.EntityFrameworkCore;


public class FlixioDbContext : DbContext
{
    public DbSet<AddonCollection> AddonCollections { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<Datastore> Datastores { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddonCollection>().ToTable("AddonCollection");
        modelBuilder.Entity<UserEntity>().ToTable("Users");
        modelBuilder.Entity<Datastore>().ToTable("Datastore");
    }
}