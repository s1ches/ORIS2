using System.Net;
using System.Text.Json;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Services;

/// <summary>
/// Responsible for send requests on pokeAPI and gets the pokemons
/// </summary>
public class PokeApiRequestMessageSender : IPokeApiRequestMessageSender
{
    private readonly HttpClient _httpClient = new();

    /// <summary>
    /// Responsible for send the request on pokeAPI and returns the JSON of result
    /// </summary>
    /// <param name="requestUrl">Request url</param>
    /// <param name="cancellationToken"></param>
    /// <returns>JSON of result</returns>
    public async Task<string> SendGetRequestAsync(Uri requestUrl, CancellationToken cancellationToken = default)
    {
        var message = new HttpRequestMessage();
        message.RequestUri = requestUrl;
        message.Method = HttpMethod.Get;

        var httpResponse = await _httpClient.SendAsync(message, cancellationToken);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(
                $"{(int)httpResponse.StatusCode}");

        return await httpResponse.Content.ReadAsStringAsync(cancellationToken);
    }

    /// <summary>
    /// Responsible for send the request on pokeAPI and Deserialize JSON result
    /// </summary>
    /// <param name="requestUrl">Request url</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Entity from pokeAPI</typeparam>
    /// <returns>Deserialized entity from pokeAPI</returns>
    public async Task<PokeApiResponse<T>> SendGetRequestAndDeserializeAsync<T>(Uri requestUrl, CancellationToken cancellationToken = default) where T : class
    {
        var resultJson = await SendGetRequestAsync(requestUrl, cancellationToken);
        
        var result = JsonSerializer.Deserialize<T>(resultJson) ?? throw new NullReferenceException(
            $"Null {nameof(T)} was returned from {requestUrl} in {nameof(PokeApiRequestMessageSender)} service");

        resultJson = JsonSerializer.Serialize(result);
        
        return new PokeApiResponse<T> { ResultValue = result, ResultJson = resultJson };
    }
}