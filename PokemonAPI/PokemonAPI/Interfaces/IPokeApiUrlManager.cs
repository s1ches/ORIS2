namespace PokemonAPI.Interfaces;

/// <summary>
/// Responsible for returns right pokemon uri
/// </summary>
public interface IPokeApiUrlManager
{
    /// <summary>
    /// Returns Uri of all pokemons info
    /// </summary>
    /// <returns> Uri of all pokemons info</returns>
    public Uri GetPokemonsInfoUri();

    /// <summary>
    /// Returns Uri of pokemon by Id or Name
    /// </summary>
    /// <param name="pokemonIdOrName">pokemon Name or Id</param>
    /// <returns>Returns Uri of pokemon</returns>
    public Uri GetPokemonUriByIdOrName(string pokemonIdOrName);
}