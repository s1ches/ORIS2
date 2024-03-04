using PokemonAPI.Models;
using PokemonAPI.Models.DTOs;

namespace PokemonAPI.Extensions;

public static class PokemonsListExtension
{
    public static List<PokemonDto> ToPokemonsDtosList(this List<Pokemon> pokemonsList)
    {
        var pokemonsDtosList = new List<PokemonDto>();
        
        foreach (var pokemon in pokemonsList)
        {
            var pokemonDto = new PokemonDto();

            pokemon.MapTo(pokemonDto);

            pokemonsDtosList.Add(pokemonDto);
        }

        return pokemonsDtosList;
    }
}