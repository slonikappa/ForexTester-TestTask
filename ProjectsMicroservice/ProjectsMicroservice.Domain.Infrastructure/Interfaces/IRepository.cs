namespace ProjectsMicroservice.Domain.Infrastructure.Interfaces;

public interface IRepository<TEntity> 
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll(int userId = 0, int skip = 0, int limit = 0);
    Task<TEntity> GetById(int userId);
    Task Create(TEntity entity);
    Task<bool> Update(TEntity entity);
    Task<bool> Delete(int userId);
}
