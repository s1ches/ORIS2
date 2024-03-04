using PokemonAPI.Exceptions;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Services;

public class PokeApiService : IPokeApiService
{
    private readonly IPokeApiUrlManager _urlManager;

    private readonly IPokeApiCacheManager _cacheManager;

    public PokeApiService(IPokeApiUrlManager urlManager, IPokeApiCacheManager cacheManager)
        => (_cacheManager, _urlManager) = (cacheManager, urlManager);

    public async Task<Pokemon> GetPokemonAsync(string pokemonSearchParameter,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(pokemonSearchParameter))
            throw new ArgumentException($"Empty value was entered in {nameof(GetPokemonAsync)}" +
                                        $" method of {nameof(PokeApiService)} service");

        pokemonSearchParameter = pokemonSearchParameter.Trim().ToLower();
        
        var requestUrl = _urlManager.GetPokemonUriByIdOrName(pokemonSearchParameter);
        
        var result =
            await _cacheManager.GetFromCacheOrPokeApiAsync<Pokemon>(pokemonSearchParameter, requestUrl,
                cancellationToken);

        return result;
    }

    public async Task<List<Pokemon>> GetPokemonsByFilterAsync(string searchValue = "", int pokemonsCount = 15,
        int pageNumber = 0, CancellationToken cancellationToken = default)
    {
        searchValue = searchValue.Trim().ToLower();

        var allPokemonsInfo = await GetPokemonsInfoAsync(cancellationToken);

        var rightPokemonsInfo = allPokemonsInfo.Pokemons
            .Where(pokemon => pokemon.PokemonName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
            .Skip(pokemonsCount * pageNumber).Take(pokemonsCount);

        var resultTasks = rightPokemonsInfo.Select(async (pokemonInfo) =>
        {
            var pokemonRequestUrl = _urlManager.GetPokemonUriByIdOrName(pokemonInfo.PokemonName);

            return await _cacheManager.GetFromCacheOrPokeApiAsync<Pokemon>(pokemonInfo.PokemonName,
                pokemonRequestUrl,
                cancellationToken);
        });

        var resultArray = await Task.WhenAll(resultTasks);

        return resultArray.ToList();
    }

    public async Task<List<Pokemon>> GetAllPokemonsAsync(int pokemonsCount, int pageNumber,
        CancellationToken cancellationToken)
    {
        return await GetPokemonsByFilterAsync("", pokemonsCount, pageNumber, cancellationToken);
    }

    private async Task<PokemonsInfo> GetPokemonsInfoAsync(CancellationToken cancellationToken = default)
    {
        var allPokemonsInfoUrl = _urlManager.GetPokemonsInfoUri();
        return await _cacheManager.GetFromCacheOrPokeApiAsync<PokemonsInfo>(nameof(PokemonsInfo), allPokemonsInfoUrl,
            cancellationToken);
    }
}