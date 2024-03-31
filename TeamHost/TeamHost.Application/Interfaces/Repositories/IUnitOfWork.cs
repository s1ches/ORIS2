using TeamHost.Domain.Common;

namespace TeamHost.Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    Task<int> SaveAndRemoveCacheAsync(CancellationToken cancellationToken, params string[] cacheKeys);
    
    Task RollbackAsync(CancellationToken cancellationToken);
}