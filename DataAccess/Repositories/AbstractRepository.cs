using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public abstract class AbstractRepository<T>(PryanikiDbContext context) : IAbstractRepository<T>
    where T : BaseModel
{
    private readonly PryanikiDbContext context = context;

    public async Task<T?> GetByIdAsync(long id, CancellationToken token)
    {
        return await context.FindAsync<T>(id, token);
    }

    public virtual async Task AddAsync(T entity, CancellationToken token)
    {
        await context.AddAsync(entity, token);
        await context.SaveChangesAsync(token);
    }

    public virtual async Task DeleteAsync(long id, CancellationToken token)
    {
        var ent = await context.FindAsync<T>(id, token);
        if (ent != null)
        {
            context.Remove(ent);
            await context.SaveChangesAsync(token);
        }
    }

    public virtual async Task<T?> UpdateAsync(T entity, CancellationToken token)
    {
        var ent = await context.FindAsync<T>(entity.Id, token);
        if (ent == null) return null;
        context.Update(entity);
        await context.SaveChangesAsync(token);
        return entity;
    }

}