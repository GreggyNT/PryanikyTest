using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>?> GetProductsAsync(CancellationToken token);
    Task<IEnumerable<Product>?> GetProductsByName(CancellationToken token,string name);
    Task<IEnumerable<Product>?> GetProductsByOrderIdAsync(CancellationToken token, long id);
}