using Core.DTO.Order.Requests;
using Core.DTO.Order.Responses;
using Core.DTO.OrderItem.Requests;
using Core.Services.Interfaces;
using DataAccess.Enums;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Mapster;

namespace Core.Services.Implementations;

public class OrderService(IOrderRepository repository):IOrderService
{
    public async Task<OrderResponse?> GetOrderByIdAsync(long id, CancellationToken token)
    {
        var order = await repository.GetByIdAsync(id, token);
        return order.Adapt<OrderResponse>();
    }

    public async Task CreateOrderAsync(CreateOrderRequest order, CancellationToken token) =>
        await repository.AddAsync(order.Adapt<Order>(), token);


    public async Task<bool?> UpdateOrderAsync(UpdateOrderRequest order, CancellationToken token) =>
        await repository.UpdateAsync(order.Adapt<Order>(), token);

    public async Task<bool?> DeleteOrderAsync(long id, CancellationToken token)
    {
        var order = await repository.GetByIdAsync(id, token);
        if (order == null) return null;
        await repository.DeleteAsync(id, token);
        order = await repository.GetByIdAsync(id, token);
        return order == null;
    }

    public async Task<IEnumerable<OrderResponse>?> GetAllOrders(CancellationToken token)
    {
        var orders =await repository.GetOrdersAsync(token);
        return orders?.Select(x => x.Adapt<OrderResponse>()).ToList();
    }

    public async Task<IEnumerable<OrderResponse>?> GetOrdersByOrderStatus(OrderStatus status, CancellationToken token)
    {
        var orders =await repository.GetOrdersByStatusAsync(token,status);
        return orders?.Select(x => x.Adapt<OrderResponse>()).ToList();
    }

    public async Task<int?> GetOrderItemQuantityAsync(CancellationToken token, long orderId, long productId) =>
        await repository.GetOrderItemQuantityAsync(token, orderId, productId);

    public async Task<IEnumerable<OrderItemDTO>?> GetOrderItemsAsync(CancellationToken token, long orderId)
    {
        var orders = await repository.GetOrderItemsAsync(token, orderId);
        return orders?.Select(x => x.Adapt<OrderItemDTO>()).ToList();
    }
}