namespace PokemonAPI.Interfaces;

/// <summary>
/// Responsible for cache interaction
/// </summary>
public interface IPokeApiCacheManager
{
    /// <summary>
    /// Returns value from cache if it has, else returns value from PokeAPI
    /// </summary>
    /// <param name="pokemonSearchParameter">Name or Id of pokemon</param>
    /// <param name="requestUrl">URL for api if cache does not exist a record of pokemon</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Value which we want to get from cache or PokeAPI</typeparam>
    /// <returns>Value from cache or from PokeAPI</returns>
    public Task<T> GetFromCacheOrPokeApiAsync<T>(string pokemonSearchParameter, Uri requestUrl,
        CancellationToken cancellationToken = default) where T : class;
}