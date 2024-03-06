using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.PokemonProperties;

public class Others
{
    [JsonPropertyName("home")]
    public Home HomeSprites { get; set; }
}