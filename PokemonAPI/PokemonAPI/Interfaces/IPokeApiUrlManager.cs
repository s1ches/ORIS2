namespace PokemonAPI.Interfaces;

public interface IPokeApiUrlManager
{
    public Uri GetPokemonsInfoUri();

    public Uri GetPokemonUriByIdOrName(string pokemonIdOrName);

    public int GetPokemonIdFromUrl(Uri pokemonUrl);
}