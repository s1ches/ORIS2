using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class StatValue
{
    [JsonPropertyName("name")]
    public string StatName { get; set; }
}