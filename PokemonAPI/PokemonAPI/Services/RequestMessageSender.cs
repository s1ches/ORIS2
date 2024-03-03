using System.Net;
using PokemonAPI.Interfaces;

namespace PokemonAPI.Services;

public class RequestMessageSender : IRequestMessageSender
{
    private readonly HttpClient _httpClient = new();

    public async Task<string> SendGetRequestAsync(Uri requestUri, CancellationToken cancellationToken = default)
    {
        var message = new HttpRequestMessage();
        message.RequestUri = requestUri;
        message.Method = HttpMethod.Get;

        var httpResponse = await _httpClient.SendAsync(message, cancellationToken);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(
                $"Request returned Response with status code {httpResponse.StatusCode}");

        return await httpResponse.Content.ReadAsStringAsync(cancellationToken);
    }
}