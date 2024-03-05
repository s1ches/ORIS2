using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace PokemonAPI.Extensions;

public static class IDistributedCacheExtension
{
    /// <summary>
    /// Returns value from cache by using key of the record
    /// </summary>
    /// <param name="cache"></param>
    /// <param name="recordKey"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Returns T if value in cache, else null</returns>
    /// <exception cref="InvalidCastException">Excception will be throw, if can not deserialize value from cache to T</exception>
    public static async Task<T?> GetValueFromCacheAsync<T>(this IDistributedCache cache, string recordKey,
        CancellationToken cancellationToken = default) where T : class
    {
        var resultJson = await cache.GetStringAsync(recordKey, cancellationToken);

        if (resultJson is null)
            return null;

        var resultValue = JsonSerializer.Deserialize<T>(resultJson) ??
                          throw new InvalidCastException("In cache was added not valid data");

        return resultValue;
    }
}