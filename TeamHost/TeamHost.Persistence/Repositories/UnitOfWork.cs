using System.Collections;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Common;
using TeamHost.Persistence.Contexts;

namespace TeamHost.Persistence.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private Hashtable _repositories;
    private bool _disposed;

    public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
    {
        _repositories ??= new Hashtable();

        var type = typeof(T).Name;

        if (_repositories.ContainsKey(type)) return (IGenericRepository<T>)_repositories[type];
        
        var repositoryType = typeof(GenericRepository<>);

        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

        _repositories.Add(type, repositoryInstance);

        return (IGenericRepository<T>)_repositories[type];
    }

    public Task RollbackAsync(CancellationToken cancellationToken)
    {
        _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveAndRemoveCacheAsync(CancellationToken cancellationToken, params string[] cacheKeys)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
            {
                //dispose managed resources
                _dbContext.Dispose();
            }
        }
        //dispose unmanaged resources
        _disposed = true;
    }
}