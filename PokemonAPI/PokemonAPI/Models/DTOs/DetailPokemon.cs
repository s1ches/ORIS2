using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class DetailPokemon : Pokemon 
{
    [JsonPropertyName("height")]
    public int Height { get; set; } 
        
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
    
    [JsonPropertyName("abilities")]
    public List<Ability> Abilities { get; set; }
    
    [JsonPropertyName("moves")]
    public List<Move> Moves { get; set; }
    
    [JsonPropertyName("stats")]
    public List<Stat> Stats { get; set; }
}