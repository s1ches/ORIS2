using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class Type
{
    [JsonPropertyName("type")]
    public TypeValue TypeValue { get; set; }
}