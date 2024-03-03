namespace PokemonAPI.Interfaces;

public interface IRequestMessageSender
{
    public Task<string> SendGetRequestAsync(Uri requestUri, CancellationToken cancellationToken = default);
}