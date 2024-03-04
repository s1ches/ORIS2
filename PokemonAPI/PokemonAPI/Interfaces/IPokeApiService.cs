using PokemonAPI.Models;

namespace PokemonAPI.Interfaces;

public interface IPokeApiService
{
    public Task<Pokemon> GetPokemonAsync(string pokemonSearchParameter, CancellationToken cancellationToken);

    public Task<List<Pokemon>> GetPokemonsByFilterAsync(string searchValue, int pokemonsCount,
        int pageNumber, CancellationToken cancellationToken);

    public Task<List<Pokemon>> GetAllPokemonsAsync(int pokemonsCount, int pageNumber,
        CancellationToken cancellationToken);
}