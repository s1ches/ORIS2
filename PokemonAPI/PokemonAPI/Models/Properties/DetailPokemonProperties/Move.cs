using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class Move
{
    [JsonPropertyName("move")]
    public MoveValue MoveValue { get; set; }
}