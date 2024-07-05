using Core.DTO_s.Product.Request;
using Core.DTO_s.Product.Response;
using Core.DTO.Order.Responses;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Mapster;

namespace Core.Services.Implementations;

public class ProductService(IProductRepository repository):IProductService
{
    public async Task<ProductResponse?> GetProductByIdAsync(long id, CancellationToken token)
    {
        var product = await repository.GetByIdAsync(id, token);
        return product.Adapt<ProductResponse>();
    }

    public async Task CreateProductAsync(CreateProductRequest order, CancellationToken token)=>
        await repository.AddAsync(order.Adapt<Product>(), token);

    public async Task<bool?> UpdateProductAsync(UpdateProductRequest order, CancellationToken token)=>
        await repository.UpdateAsync(order.Adapt<Product>(), token);
    public async Task<bool?> DeleteProductAsync(long id, CancellationToken token)
    {
        var product = await repository.GetByIdAsync(id, token);
        if (product == null) return null;
        await repository.DeleteAsync(id, token);
        product = await repository.GetByIdAsync(id, token);
        return product == null;
    }

    public async Task<IEnumerable<ProductResponse>?> GetAllProducts(CancellationToken token)
    {
        var products =await repository.GetProductsAsync(token);
        return products?.Select(x => x.Adapt<ProductResponse>()).ToList();
    }

    public async Task<IEnumerable<ProductResponse>?> GetProductsByName(CancellationToken token, string name)
    {
        var products = await repository.GetProductsByNameAsync(token, name);
        return products?.Select(x => x.Adapt<ProductResponse>()).ToList();
    }

    public async Task<IEnumerable<ProductResponse>?> GetProductsByOrderIdAsync(CancellationToken token, long id)
    {
        var products = await repository.GetProductsByOrderIdAsync(token, id);
        return products?.Select(x => x.Adapt<ProductResponse>()).ToList();
    }
}