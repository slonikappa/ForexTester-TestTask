namespace UserMicroservice.Domain.Infastructure.Interfaces;

public interface IRepository<TEntity>
        where TEntity : class
{
    void Add(TEntity entity);
    Task<TEntity?> GetItem(int id);
    Task<List<TEntity>> GetAll();
    void Update(TEntity entity);
    void DeleteByItem(TEntity entity);
    void DeleteById(int id);
}
