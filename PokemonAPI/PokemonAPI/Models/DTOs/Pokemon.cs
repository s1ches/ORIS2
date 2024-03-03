using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

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
}