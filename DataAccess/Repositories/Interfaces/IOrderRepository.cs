using DataAccess.Enums;
using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>?> GetOrdersAsync(CancellationToken token);
    
    Task<int?> GetOrderItemQuantityAsync(CancellationToken token, long orderId, long productId);

    Task<IEnumerable<OrderItem>?> GetOrderItemsAsync(CancellationToken token, long orderId);
    
    Task<IEnumerable<Order>?> GetOrdersByStatusAsync(CancellationToken token, OrderStatus status);


}