using Core.DTO_s.Product.Request;
using Core.DTO_s.Product.Response;
using Core.DTO.Order.Requests;
using Core.DTO.Order.Responses;

namespace Core.Services.Interfaces;

public interface IProductService
{
    Task<ProductResponse?> GetProductByIdAsync(long id,CancellationToken token);
    
    Task CreateProductAsync(CreateProductRequest order, CancellationToken token);
    
    Task<bool?> UpdateProductAsync(UpdateProductRequest order, CancellationToken token);
    
    Task<bool?> DeleteProductAsync(long id, CancellationToken token);
    
    Task<IEnumerable<ProductResponse>?> GetAllProducts(CancellationToken token);
    
    Task<IEnumerable<ProductResponse>?> GetProductsByName(CancellationToken token,string name);
    
    Task<IEnumerable<ProductResponse>?> GetProductsByOrderIdAsync(CancellationToken token, long id);
}