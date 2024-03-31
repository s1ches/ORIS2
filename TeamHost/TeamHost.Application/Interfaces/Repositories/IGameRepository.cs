using TeamHost.Domain.Entities;

namespace TeamHost.Application.Interfaces.Repositories;

/// <summary>
/// Репозиторий сущности <see cref="Game"/>
/// </summary>
public interface IGameRepository
{
    Task<Game?> GetGameByIdAsync(int id, CancellationToken cancellationToken);
}