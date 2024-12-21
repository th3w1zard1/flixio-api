namespace Flixio.Api.Data.Repositories;

public class AddonCollectionRepository(IDbContextFactory<FlixioDbContext> dbContextFactory) : IRepository<AddonCollection, int>
{
    public async Task<AddonCollection?> GetAsync(int id)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        return await dbContext.AddonCollections.FindAsync(id);
    }

    public async Task<IEnumerable<AddonCollection>> GetAllAsync()
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        var data = await dbContext.AddonCollections.ToListAsync();
        
        return data;
    }

    public async Task<AddonCollection> AddAsync(AddonCollection entity)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        dbContext.AddonCollections.Add(entity);
        await dbContext.SaveChangesAsync();
        
        return entity;
    }

    public async Task<AddonCollection> UpdateAsync(AddonCollection entity)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        dbContext.AddonCollections.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<AddonCollection> DeleteAsync(AddonCollection entity)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        dbContext.AddonCollections.Remove(entity);
        
        await dbContext.SaveChangesAsync();
        
        return entity;
    }
}