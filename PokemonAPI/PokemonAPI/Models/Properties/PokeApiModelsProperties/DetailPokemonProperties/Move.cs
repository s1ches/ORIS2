using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.DetailPokemonProperties;

public class Move
{
    [JsonPropertyName("move")]
    public MoveValue MoveValue { get; set; }
}