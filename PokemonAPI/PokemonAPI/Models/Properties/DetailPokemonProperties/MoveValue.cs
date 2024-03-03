using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class MoveValue
{
    [JsonPropertyName("name")]
    public string MoveName { get; set; }
}