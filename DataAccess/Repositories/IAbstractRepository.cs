namespace DataAccess.Repositories;

public interface IAbstractRepository<T>
{
    Task<T?> GetByIdAsync(long id, CancellationToken token);
    Task AddAsync(T entity, CancellationToken token);
    Task<T?> UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(long id, CancellationToken token);
}