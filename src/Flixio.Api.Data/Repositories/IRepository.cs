namespace Flixio.Api.Data.Repositories;

public interface IRepository<TEntity, in TIdentity> where TEntity : class
{
    Task<TEntity?> GetAsync(TIdentity id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}