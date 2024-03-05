using PokemonAPI.Interfaces;

namespace PokemonAPI.Services;

/// <summary>
/// Responsible for returns right pokemon uri
/// </summary>
public class PokeApiUrlManager : IPokeApiUrlManager
{
    /// <summary>
    /// Returns Uri of all pokemons info
    /// </summary>
    /// <returns> Uri of all pokemons info</returns>
    public Uri GetPokemonsInfoUri() => new("https://pokeapi.co/api/v2/pokemon?limit=10000&offset=0");

    /// <summary>
    /// Returns Uri of pokemon by Id or Name
    /// </summary>
    /// <param name="pokemonIdOrName">pokemon Name or Id</param>
    /// <returns>Returns Uri of pokemon</returns>
    public Uri GetPokemonUriByIdOrName(string pokemonIdOrName) =>
        new($"https://pokeapi.co/api/v2/pokemon/{pokemonIdOrName}/");
}