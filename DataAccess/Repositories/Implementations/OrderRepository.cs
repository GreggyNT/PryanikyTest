using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations;

public class OrderRepository(PryanikiDbContext context) :AbstractRepository<Order>(context),IOrderRepository
{
    private readonly PryanikiDbContext _context = context;

    public async Task<IEnumerable<Order>?> GetOrdersAsync(CancellationToken token) =>
        await _context.Orders.ToListAsync(cancellationToken: token);


}