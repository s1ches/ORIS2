using PokemonAPI.Models;

namespace PokemonAPI.Interfaces;

/// <summary>
/// Responsible for send requests on API and gets the pokemons
/// </summary>
public interface IPokeApiRequestMessageSender
{
    /// <summary>
    /// Responsible for send the request on API and returns the JSON of result
    /// </summary>
    /// <param name="requestUrl">Request url</param>
    /// <param name="cancellationToken"></param>
    /// <returns>JSON of result</returns>
    public Task<string> SendGetRequestAsync(Uri requestUrl, CancellationToken cancellationToken = default);

    /// <summary>
    /// Responsible for send the request on API and Deserialize JSON result
    /// </summary>
    /// <param name="requestUrl">Request url</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Entity from API</typeparam>
    /// <returns>Deserialized entity from API</returns>
    public Task<PokeApiResponse<T>> SendGetRequestAndDeserializeAsync<T>(Uri requestUrl,
        CancellationToken cancellationToken = default) where T: class;
}