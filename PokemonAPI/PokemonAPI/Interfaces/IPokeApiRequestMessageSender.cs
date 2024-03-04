using PokemonAPI.Models;

namespace PokemonAPI.Interfaces;

public interface IPokeApiRequestMessageSender
{
    public Task<string> SendGetRequestAsync(Uri requestUrl, CancellationToken cancellationToken = default);

    public Task<PokeApiResponse<T>> SendGetRequestAndDeserializeAsync<T>(Uri requestUrl,
        CancellationToken cancellationToken = default) where T: class;
}