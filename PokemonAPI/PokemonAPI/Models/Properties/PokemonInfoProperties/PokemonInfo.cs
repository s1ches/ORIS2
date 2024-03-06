using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokemonInfoProperties;

public class PokemonInfo
{
    [JsonPropertyName("name")]
    public string PokemonName { get; set; }
    
    [JsonPropertyName("url")]
    public Uri PokemonUrl { get; set; }
}