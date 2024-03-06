using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.PokemonProperties;

public class Type
{
    [JsonPropertyName("type")]
    public TypeValue TypeValue { get; set; }
}