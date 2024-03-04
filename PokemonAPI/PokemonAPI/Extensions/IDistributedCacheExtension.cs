using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace PokemonAPI.Extensions;

public static class IDistributedCacheExtension
{
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