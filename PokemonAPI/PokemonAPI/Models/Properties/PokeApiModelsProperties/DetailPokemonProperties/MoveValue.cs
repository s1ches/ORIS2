using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.DetailPokemonProperties;

public class MoveValue
{
    [JsonPropertyName("name")]
    public string MoveName { get; set; }
}