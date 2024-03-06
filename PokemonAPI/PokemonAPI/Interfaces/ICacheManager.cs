namespace PokemonAPI.Interfaces;

/// <summary>
/// Responsible for cache interaction
/// </summary>
public interface ICacheManager
{
    /// <summary>
    /// Returns value from cache if it has, else returns value from API
    /// </summary>
    /// <param name="searchParameter">Search parameter</param>
    /// <param name="requestUrl">URL for api if cache does not exist a record</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Value which we want to get from cache or API</typeparam>
    /// <returns>Value from cache or API</returns>
    public Task<T> GetFromCacheOrApiAsync<T>(string searchParameter, Uri requestUrl,
        CancellationToken cancellationToken = default) where T : class;
}