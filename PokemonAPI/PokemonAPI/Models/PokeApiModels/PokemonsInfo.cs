using System.Text.Json.Serialization;
using PokemonAPI.Models.Properties.PokemonInfoProperties;

namespace PokemonAPI.Models.PokeApiModels;

public class PokemonsInfo
{
    [JsonPropertyName("count")]
    public int PokemonsCount { get; set; }
    
    [JsonPropertyName("results")]
    public List<PokemonInfo> Pokemons { get; set; }
}