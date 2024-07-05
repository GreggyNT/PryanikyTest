using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations;

public class ProductRepository(PryanikiDbContext context):AbstractRepository<Product>(context),IProductRepository
{
    private readonly PryanikiDbContext _context = context;
    public async Task<IEnumerable<Product>?> GetProductsAsync(CancellationToken token)
        => await _context.Products.ToListAsync(cancellationToken: token);

    public async Task<IEnumerable<Product>?> GetProductsByNameAsync(CancellationToken token,string name)
    {
        var result = _context.Products.Select(x => x).Where(x => x.Name.Contains(name));
        if (!result.Any()) return null;
        return await result.ToListAsync(token);
    }
    public async Task<IEnumerable<Product>?> GetProductsByOrderIdAsync(CancellationToken token, long id)
    {
        var result = await _context.OrderItems.Select(item => item).Where(x => x.OrderId == id).Select(x=>x.ProductId).ToListAsync(cancellationToken: token);
        if (result.Count==0) return null;
        return await _context.Products.Select(x => x).Where(x => result.Contains(x.Id)).ToListAsync(token);
    }
}