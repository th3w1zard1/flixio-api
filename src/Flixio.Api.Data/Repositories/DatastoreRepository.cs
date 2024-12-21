namespace Flixio.Api.Data.Repositories;

public class DatastoreRepository(IDbContextFactory<FlixioDbContext> dbContextFactory) : IRepository<Datastore, string>
{
    public async Task<Datastore?> GetAsync(string id)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        return await dbContext.Datastores.FindAsync(id);
    }

    public async Task<IEnumerable<Datastore>> GetAllAsync()
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        var data = await dbContext.Datastores.ToListAsync();
        
        return data;
    }

    public async Task<Datastore> AddAsync(Datastore entity)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        dbContext.Datastores.Add(entity);
        await dbContext.SaveChangesAsync();
        
        return entity;
    }

    public async Task<Datastore> UpdateAsync(Datastore entity)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        dbContext.Datastores.Update(entity);
        await dbContext.SaveChangesAsync();
        
        return entity;
    }

    public async Task<Datastore> DeleteAsync(Datastore entity)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        dbContext.Datastores.Remove(entity);
        
        await dbContext.SaveChangesAsync();
        
        return entity;
    }
}