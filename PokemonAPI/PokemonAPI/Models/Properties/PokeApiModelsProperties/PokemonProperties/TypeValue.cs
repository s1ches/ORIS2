using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.PokemonProperties;

public class TypeValue
{
    [JsonPropertyName("name")]
    public string TypeName { get; set; }
}