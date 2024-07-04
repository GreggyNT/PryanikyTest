using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>?> GetOrdersAsync(CancellationToken token);
}