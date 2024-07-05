using DataAccess.Enums;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations;

public class OrderRepository(PryanikiDbContext context) :AbstractRepository<Order>(context),IOrderRepository
{
    private readonly PryanikiDbContext _context = context;

    public async Task<IEnumerable<Order>?> GetOrdersAsync(CancellationToken token) =>
        await _context.Orders.ToListAsync(cancellationToken: token);

    public async Task<int?> GetOrderItemQuantityAsync(CancellationToken token, long orderId, long productId)
    {
        var result = await _context.OrderItems.FirstOrDefaultAsync(x => x.ProductId == productId && x.OrderId == orderId, token);
        return result?.Quantity;
    }

    public async Task<IEnumerable<OrderItem>?> GetOrderItemsAsync(CancellationToken token, long orderId) 
    {
       var res =  await _context.OrderItems.Select(x => x).Where(x => x.OrderId == orderId).ToListAsync(token);
       return res.Count == 0 ? null : res;
    }

    public async Task<IEnumerable<Order>?> GetOrdersByStatusAsync(CancellationToken token, OrderStatus status)
    {
        var res =  await _context.Orders.Select(x => x).Where(x => x.Status==status).ToListAsync(token);
        return res.Count == 0 ? null : res;
    }
}