namespace PokemonAPI.Interfaces;

public interface IPokeApiCacheManager
{
    public Task<T> GetFromCacheOrPokeApiAsync<T>(string pokemonSearchParameter, Uri requestUrl,
        CancellationToken cancellationToken = default) where T : class;
}