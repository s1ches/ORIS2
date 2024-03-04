using Microsoft.Extensions.Caching.Distributed;
using PokemonAPI.Extensions;
using PokemonAPI.Interfaces;

namespace PokemonAPI.Services;

public class PokeApiCacheManager : IPokeApiCacheManager
{
    private readonly IDistributedCache _cache;

    private readonly IPokeApiRequestMessageSender _messageSender;

    public PokeApiCacheManager(IDistributedCache cache, IPokeApiRequestMessageSender messageSender) =>
        (_cache, _messageSender) = (cache, messageSender);

    private string GetRecordKey<T>(string searchParameter) => $"{typeof(T).Name}: {searchParameter}";

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