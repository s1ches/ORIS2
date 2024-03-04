using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class PokemonsInfo
{
    [JsonPropertyName("count")]
    public int PokemonsCount { get; set; }
    
    [JsonPropertyName("results")]
    public List<PokemonInfo> Pokemons { get; set; }
}