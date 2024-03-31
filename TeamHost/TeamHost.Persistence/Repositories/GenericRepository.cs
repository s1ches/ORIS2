using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Common;

namespace TeamHost.Persistence.Repositories;

public class GenericRepository<T>(DbContext dbContext) : IGenericRepository<T>
    where T : BaseAuditableEntity
{
    public IQueryable<T> Entities => dbContext.Set<T>();
 
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await dbContext.Set<T>().AddAsync(entity, cancellationToken);
        return entity;
    }
 
    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        var exist = await dbContext.Set<T>().FindAsync(new object?[] { entity.Id }, cancellationToken);

        if (exist is null)
            return;
        
        dbContext.Entry(exist).CurrentValues.SetValues(entity);
    }
 
    public Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }
 
    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<T>()
            .ToListAsync(cancellationToken: cancellationToken);
    }
 
    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<T>().FindAsync(new object?[] { id }, cancellationToken);
    }
}