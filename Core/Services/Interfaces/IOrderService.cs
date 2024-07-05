using Core.DTO.Order.Requests;
using Core.DTO.Order.Responses;
using Core.DTO.OrderItem.Requests;
using DataAccess.Enums;

namespace Core.Services.Interfaces;

public interface IOrderService
{
    Task<OrderResponse?> GetOrderByIdAsync(long id,CancellationToken token);
    
    Task CreateOrderAsync(CreateOrderRequest order, CancellationToken token);
    
    Task<bool?> UpdateOrderAsync(UpdateOrderRequest order, CancellationToken token);
    
    Task<bool?> DeleteOrderAsync(long id, CancellationToken token);
    
    Task<IEnumerable<OrderResponse>?> GetAllOrders(CancellationToken token);
    
    Task<IEnumerable<OrderResponse>?> GetOrdersByOrderStatus(OrderStatus status, CancellationToken token);
    
    Task<int?> GetOrderItemQuantityAsync(CancellationToken token, long orderId, long productId);
    
    Task<IEnumerable<OrderItemDTO>?> GetOrderItemsAsync(CancellationToken token, long orderId);
    
}