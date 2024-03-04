using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class TypeValue
{
    [JsonPropertyName("name")]
    public string TypeName { get; set; }
}