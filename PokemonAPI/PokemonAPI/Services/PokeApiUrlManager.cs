using PokemonAPI.Interfaces;

namespace PokemonAPI.Services;

public class PokeApiUrlManager : IPokeApiUrlManager
{
    public Uri GetPokemonsInfoUri() => new("https://pokeapi.co/api/v2/pokemon?limit=10000&offset=0");

    public Uri GetPokemonUriByIdOrName(string pokemonIdOrName) =>
        new($"https://pokeapi.co/api/v2/pokemon/{pokemonIdOrName}/");

    public int GetPokemonIdFromUrl(Uri pokemonUrl)
    {
        var urlParts = pokemonUrl.AbsoluteUri.Split("/");
        
        return int.Parse(urlParts.First(part => int.TryParse(part, out _)));
    }
}