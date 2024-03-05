using Microsoft.Extensions.Caching.Distributed;
using PokemonAPI.Extensions;
using PokemonAPI.Interfaces;

namespace PokemonAPI.Services;

/// <summary>
/// Responsible for cache interaction
/// </summary>
public class PokeApiCacheManager : IPokeApiCacheManager
{
    private readonly IDistributedCache _cache;
    
    private readonly IPokeApiRequestMessageSender _messageSender;

    public PokeApiCacheManager(IDistributedCache cache, IPokeApiRequestMessageSender messageSender) =>
        (_cache, _messageSender) = (cache, messageSender);

    /// <summary>
    /// Returns right key for searching a value in cache
    /// </summary>
    /// <param name="searchParameter">A part of key(name of Pokemon or Id)</param>
    /// <typeparam name="T">Type of value</typeparam>
    /// <returns>Right Record Key</returns>
    private string GetRecordKey<T>(string searchParameter) => $"{typeof(T).Name}: {searchParameter}";

    /// <summary>
    /// Returns value from cache if it has, else returns value from PokeAPI
    /// </summary>
    /// <param name="pokemonSearchParameter">Name or Id of pokemon</param>
    /// <param name="requestUrl">URL for api if cache does not exist a record of pokemon</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Value which we want to get from cache or PokeAPI</typeparam>
    /// <returns>Value from cache or from PokeAPI</returns>
    public async Task<T> GetFromCacheOrPokeApiAsync<T>(string pokemonSearchParameter, Uri requestUrl,
        CancellationToken cancellationToken = default) where T : class
    {
        var resultFromCache =
            await _cache.GetValueFromCacheAsync<T>(GetRecordKey<T>(pokemonSearchParameter),
                cancellationToken: cancellationToken);

        if (resultFromCache is not null)
            return resultFromCache;

        var resultFromApi = await _messageSender.SendGetRequestAndDeserializeAsync<T>(requestUrl, cancellationToken);

        await _cache.SetStringAsync(GetRecordKey<T>(pokemonSearchParameter), resultFromApi.ResultJson,
            cancellationToken);

        return resultFromApi.ResultValue;
    }
}