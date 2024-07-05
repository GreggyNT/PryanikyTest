using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IProductRepository:IAbstractRepository<Product>
{
    Task<IEnumerable<Product>?> GetProductsAsync(CancellationToken token);
    Task<IEnumerable<Product>?> GetProductsByNameAsync(CancellationToken token,string name);
    Task<IEnumerable<Product>?> GetProductsByOrderIdAsync(CancellationToken token, long id);
}