using TeamHost.Domain.Common.Interfaces;

namespace TeamHost.Application.Interfaces.Repositories;

/// <summary>
/// Дженерик репозиторий
/// </summary>
/// <typeparam name="TEntity">Сущность</typeparam>
public interface IGenericRepository<TEntity> 
    where TEntity : class, IEntity
{
    IQueryable<TEntity> Entities { get; }
 
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}