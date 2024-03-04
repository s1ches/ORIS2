using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class AbilityValue
{
    [JsonPropertyName("name")]
    public string AbilityName { get; set; }
}