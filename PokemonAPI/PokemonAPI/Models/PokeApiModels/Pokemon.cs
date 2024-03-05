using System.Text.Json.Serialization;

namespace PokemonAPI.Models.PokeApiModels;

public class Pokemon
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("sprites")]
    public Sprites Sprites { get; set; }

    [JsonPropertyName("types")]
    public List<Type> Types { get; set; }
    
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