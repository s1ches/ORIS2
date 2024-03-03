using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class Ability
{
    [JsonPropertyName("ability")]
    public AbilityValue AbilityValue { get; set; }
}