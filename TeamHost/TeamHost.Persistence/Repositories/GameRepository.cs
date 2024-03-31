using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Repositories;

public class GameRepository(IGenericRepository<Game> genericRepository) : IGameRepository
{
    public async Task<Game?> GetGameByIdAsync(int id, CancellationToken cancellationToken)
        => await genericRepository.GetByIdAsync(id, cancellationToken);
}